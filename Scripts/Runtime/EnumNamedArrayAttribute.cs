using UnityEngine;

namespace PUCPR.AttriX
{
    public sealed class EnumNamedArrayAttribute : PropertyAttribute
    {
        public string[] names;

        public EnumNamedArrayAttribute(System.Type names_enum_type)
        {
            this.names = System.Enum.GetNames(names_enum_type);
        }
    }
}
