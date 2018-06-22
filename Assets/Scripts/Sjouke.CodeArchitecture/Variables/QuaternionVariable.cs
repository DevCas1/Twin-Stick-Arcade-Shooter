using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/Quaternion")]
    public class QuaternionVariable : BaseVariable<Quaternion>
    {
        public void SetValue(QuaternionVariable value) => Value = value.Value;

        public void MultiplyValue(Quaternion amount) => Value *= amount;

        public void MultiplyValue(QuaternionVariable amount) => Value *= amount.Value;
    }
}