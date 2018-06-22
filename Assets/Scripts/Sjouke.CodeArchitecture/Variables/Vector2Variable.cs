using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/Vector2")]
    public class Vector2Variable : BaseVariable<Vector2>
    {
        public void SetValue(Vector2Variable value) => Value = value.Value;

        public void ApplyChange(Vector2 amount) => Value += amount;

        public void ApplyChange(Vector2Variable amount) => Value += amount.Value;
    }
}