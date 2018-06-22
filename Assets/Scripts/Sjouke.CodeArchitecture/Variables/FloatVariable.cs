using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/Float")]
    public class FloatVariable : BaseVariable<float>
    {
        public void SetValue(FloatVariable value) => Value = value.Value;

        public void AddValue(float amount) => Value += amount;

        public void AddValue(FloatVariable amount) => Value += amount.Value;
    }
}