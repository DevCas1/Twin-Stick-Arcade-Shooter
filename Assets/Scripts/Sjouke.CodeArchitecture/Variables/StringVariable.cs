using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/String")]
    public class StringVariable : BaseVariable<string>
    {
        public void SetValue(StringVariable value) => Value = value.Value;

        public void ApplyChange(string amount) => Value += amount;

        public void ApplyChange(StringVariable amount) => Value += amount.Value;
    }
}