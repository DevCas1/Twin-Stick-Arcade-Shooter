using System.Collections.Generic;
using UnityEngine;

namespace Sjouke.CodeArchitecture.Variables
{
    [CreateAssetMenu(menuName = "Variables/short List")]
    public class ShortListVariable : BaseVariable<List<short>>
    {
        public void SetValue(ShortListVariable value) => Value = value.Value;
    }
}