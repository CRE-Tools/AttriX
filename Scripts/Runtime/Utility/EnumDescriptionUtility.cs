using System;
using System.ComponentModel;
using System.Reflection;


namespace PUCPR.AttriX
{
    public static class EnumDescriptionUtility
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}
