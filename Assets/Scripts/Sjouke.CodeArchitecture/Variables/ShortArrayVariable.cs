using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/Short Array")]
    public class ShortArrayVariable : BaseVariable<short[]>
    {
        public void SetValue(ShortArrayVariable value) => Value = value.Value;
    }
}