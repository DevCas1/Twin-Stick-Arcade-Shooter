using UnityEngine;
using System.Collections.Generic;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/Float List")]
    public class FloatListVariable : BaseVariable<List<float>>
    {
        public void SetValue(FloatListVariable value) => Value = value.Value;
    }
}