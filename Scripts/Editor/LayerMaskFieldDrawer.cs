using UnityEditor;
using UnityEngine;

namespace PUCPR.AttriX.Editor
{
    [CustomPropertyDrawer(typeof(LayerMaskFieldAttribute))]
    public class LayerMaskFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.Integer)
            {
                property.intValue = EditorGUI.LayerField(position, label, property.intValue);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "[Layer] must be int!");
            }
        }
    }
}
