using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/Short")]
    public class ShortVariable : BaseVariable<short>
    {
        public void SetValue(ShortVariable value) => Value = value.Value;

        public void AddValue(short amount) => Value += amount;

        public void AddValue(ShortVariable amount) => Value += amount.Value;
    }
}