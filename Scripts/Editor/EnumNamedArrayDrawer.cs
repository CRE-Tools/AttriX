using UnityEditor;
using UnityEngine;

namespace PUCPR.AttriX.Editor
{
    [CustomPropertyDrawer(typeof(EnumNamedArrayAttribute))]
    public sealed class EnumNamedArrayDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnumNamedArrayAttribute enumNames = attribute as EnumNamedArrayAttribute;

            int index = System.Convert.ToInt32(
                property.propertyPath.Substring(
                    property.propertyPath.IndexOf("[")).Replace("[", "").Replace("]", ""));

            label.text = enumNames.names[index];

            EditorGUI.PropertyField(position, property, label, true);
        }
    }
}
