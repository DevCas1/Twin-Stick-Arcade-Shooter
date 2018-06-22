using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/Double")]
    public class DoubleVariable : BaseVariable<double>
    {
        public void SetValue(DoubleVariable value) => Value = value.Value;

        public void AddValue(double amount) => Value += amount;

        public void AddValue(DoubleVariable amount) => Value += amount.Value;
    }
}