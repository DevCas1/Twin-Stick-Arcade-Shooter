using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/Bool")]
    public class BoolVariable : BaseVariable<bool>
    {
        public void SetValue(BoolVariable value) => Value = value.Value;
    }
}