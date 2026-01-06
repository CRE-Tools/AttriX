using System;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace PUCPR.AttriX.Editor
{
    [CustomPropertyDrawer(typeof(DropdownEnumStringAttribute))]
    public class DropdownEnumStringDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.LabelField(position, label.text, "Property must be a string!");
                return;
            }

            var attr = (DropdownEnumStringAttribute)attribute;

            if (!attr.EnumType.IsEnum)
            {
                EditorGUI.LabelField(position, label.text, "Attribute must be an enum!");
                return;
            }

            var enumValues = Enum.GetValues(attr.EnumType).Cast<Enum>().ToArray();

            string[] descriptions = enumValues
                .Select(EnumDescriptionUtility.GetDescription)
                .ToArray();

            int index = Mathf.Max(
                0,
                Array.IndexOf(descriptions, property.stringValue));

            index = EditorGUI.Popup(position, index, descriptions);

            property.stringValue = descriptions[index];
        }
    }
}
