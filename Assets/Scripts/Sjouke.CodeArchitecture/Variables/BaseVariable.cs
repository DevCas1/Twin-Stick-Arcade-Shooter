using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    public abstract class BaseVariable<T> : ScriptableObject
    {
        public delegate void ValueChangeEvent(T value);
        public event ValueChangeEvent OnValueChange;

#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
        [Tooltip("Reset this variable's value after exiting playmode.")]
        public bool ResetValue = false;
        private T _originalValue;

        private void OnEnable() => _originalValue = _value;

        private void OnDisable() => _value = _originalValue;
#endif
        protected T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value.Equals(_value)) return;
                OnValueChange?.Invoke(value);
                _value = value;
            }
        }

        public void SetValue(T value) => Value = value;
    }
}