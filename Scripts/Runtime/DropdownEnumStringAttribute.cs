using System;
using UnityEngine;


namespace PUCPR.AttriX
{
    public class DropdownEnumStringAttribute : PropertyAttribute
    {
        public Type EnumType;
        public DropdownEnumStringAttribute(Type enumType) => EnumType = enumType;
    }
}