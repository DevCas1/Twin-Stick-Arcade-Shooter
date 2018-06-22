using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/Int")]
    public class IntVariable : BaseVariable<int>
    {
        public void SetValue(IntVariable value) => Value = value.Value;

        public void AddValue(int amount) => Value += amount;

        public void AddValue(IntVariable amount) => Value += amount.Value;
    }
}