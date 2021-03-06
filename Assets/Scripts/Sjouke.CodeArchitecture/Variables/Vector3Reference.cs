﻿namespace Sjouke.CodeArchitecture.Variables
{
	using UnityEngine;
    [System.Serializable]
    public class Vector3Reference
    {
        public bool UseConstant = true;
        public Vector3 ConstantValue;
        public Vector3Variable Variable;

        public Vector3 Value => UseConstant ? ConstantValue : Variable.Value;
    }
}