using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/Vector3")]
    public class Vector3Variable : BaseVariable<Vector3>
    {
        public void SetValue(Vector3Variable value) => Value = value.Value;

        public void ApplyChange(Vector3 amount) => Value += amount;

        public void ApplyChange(Vector3Variable amount) => Value += amount.Value;
    }
}