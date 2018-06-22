using System;
using UnityEngine;
using Sjouke.CodeArchitecture.Variables;
using Sjouke.CodeArchitecture.Events;

namespace Sjouke.Input.New
{
    public enum InputButtonState { Pressed, Hold, Released }

    [Serializable]
    public abstract class InputObject
    {
        [Tooltip("The name of this Input.")]
        public string Name;
        [Tooltip("The positive key of the input.")]
        public KeyCode Positive;
        [Tooltip("The required state of the key for the input to register.")]
        public InputButtonState RequiredState;
    }

    public sealed class MouseInput
    {
        public Vector2Variable MousePosition;
        public Vector2Variable MouseDelta;
    }

    [Serializable]
    public sealed class ValueInputObject : InputObject
    {
        [Tooltip("The negative key of the input.")]
        public KeyCode Negative;
        [Tooltip("The required state of the NEGATIVE key for the input to register.")]
        public InputButtonState RequiredNegativeState;
        [Tooltip("The FloatVariable the value will be stored in.")]
        public FloatVariable InputVariable;
    }

    [Serializable]
    public sealed class ButtonInputObject : InputObject
    {
        [Tooltip("The GameEvent to trigger if the input is registered.")]
        public GameEvent InputEvent;
    }

    [Serializable]
    public sealed class AxisInputObject
    {
        [Tooltip("The name of this Input. Needs to be the same as in Unity's Input Manager!")]
        public string Name;
        [Tooltip("Get the raw version of the virtual axis? (No smoothing filter will be applied.)")]
        public bool GetRawValue = false;
        [Tooltip("The FloatVariable the value will be stored in.")]
        public FloatVariable Variable;
    }

    public sealed class NewInputUpdater : MonoBehaviour
    {
        [Tooltip("All relevant data about the Mouse input.")]
        public MouseInput Mouse;
        [Tooltip("Input values from 0 to 1, based on KeyCode associated keys. (Typically used for keyboard values)")]
        public ValueInputObject[] InputKeyAxes;
        [Tooltip("Input events, raised by KeyCode associated keys. (Typically used for keyboard, mouse and controller buttons)")]
        public ButtonInputObject[] InputButtons;
        [Tooltip("Input values, based on any input the Unity Input Manager is capable of. (USE THIS ONLY FOR VALUES THAT CANNOT BE FOUND USING UnityEngine.KeyCode, OR IF YOU REALLY NEED PRECISE VALUES!)")]
        public AxisInputObject[] InputAxes;

        private void Update()
        {
            UpdateMouseInput();
            if (InputKeyAxes.Length > 0) UpdateInputKeyAxes();
            if (InputButtons.Length > 0) UpdateInputButtons();
            if (InputAxes.Length > 0) UpdateInputAxes();
        }

        private void UpdateMouseInput()
        {
            try
            {
                Mouse.MouseDelta.Value = Mouse.MousePosition.Value - (Vector2)UnityEngine.Input.mousePosition;
                Mouse.MousePosition.Value = UnityEngine.Input.mousePosition;
            }
            catch (Exception e)
            {
                Debug.LogError($"NewInputUpdater (MouseInput): {e.Message}");
            }
        }

        private void UpdateInputKeyAxes()
        {
            foreach (var input in InputKeyAxes)
            {
                try
                {
                    input.InputVariable.Value = (CheckButton(input.Positive, input.RequiredState) ? 1 : 0) - (CheckButton(input.Negative, input.RequiredNegativeState) ? 1 : 0);
                }
                catch (Exception e)
                {
                    Debug.LogError($"NewInputUpdater (InputKeyAxes): {e.Message}");
                }
                return;
            }
        }

        private void UpdateInputButtons()
        {
            foreach (var input in InputButtons)
            {
                try
                {
                    if (CheckButton(input.Positive, input.RequiredState))
                        input.InputEvent.Raise();
                }
                catch (Exception e)
                {
                    Debug.LogError($"NewInputUpdater (InputButtons): {e.Message}");
                }
            }
        }

        private bool CheckButton(KeyCode inputKey, InputButtonState state)
        {
            switch (state)
            {
                case InputButtonState.Pressed:
                    return UnityEngine.Input.GetKeyDown(inputKey);

                case InputButtonState.Hold:
                    return UnityEngine.Input.GetKey(inputKey);

                case InputButtonState.Released:
                    return UnityEngine.Input.GetKeyUp(inputKey);
            }
            return false;
        }

        private void UpdateInputAxes()
        {
            foreach (var input in InputAxes)
            {
                try
                {
                    input.Variable.Value = UnityEngine.Input.GetAxis(input.Name);
                }
                catch (Exception e)
                {
                    Debug.LogError($"NewInputUpdater (InputAxes): {e.Message}");
                }
            }
        }
    }
}