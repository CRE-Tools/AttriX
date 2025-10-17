using UnityEditor;
using UnityEngine;

namespace PUCPR.AttriX.Editor
{
    [CustomPropertyDrawer(typeof(UnderlineSeparatorAttribute))]
    public sealed class UnderlineSeparatorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            UnderlineSeparatorAttribute lineAttr = attribute as UnderlineSeparatorAttribute;

            EditorGUI.PropertyField(position, property, label, true);

            Rect lineRect = new Rect(position.x, position.y + lineAttr.height + (lineAttr.spacing * 2), position.width, lineAttr.height);
            EditorGUI.DrawRect(lineRect, Color.gray);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            UnderlineSeparatorAttribute lineAttr = attribute as UnderlineSeparatorAttribute;
            return base.GetPropertyHeight(property, label) + lineAttr.height + (lineAttr.spacing * 2);
        }
    }
}
