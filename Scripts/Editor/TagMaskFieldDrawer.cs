using UnityEditor;
using UnityEngine;

namespace PUCPR.AttriX.Editor
{
    [CustomPropertyDrawer(typeof(TagMaskFieldAttribute))]
    public sealed class TagMaskFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.String)
            {
                property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "[Tag] must be string!");
            }
        }
    }
}
