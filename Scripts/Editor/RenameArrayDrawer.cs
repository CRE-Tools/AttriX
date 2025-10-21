using UnityEditor;
using UnityEngine;

namespace PUCPR.AttriX.Editor
{
    [CustomPropertyDrawer(typeof(RenameArrayAttribute))]
    public sealed class RenameArrayDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var attribute = (RenameArrayAttribute)this.attribute;

            string path = property.propertyPath;
            int index = GetIndexFromPath(path);

            if (index >= 0)
            {
                label.text = $"{attribute.BaseName} {index + 1} (index:{index})";
            }

            EditorGUI.PropertyField(position, property, label, true);
        }

        private int GetIndexFromPath(string path)
        {
            int start = path.LastIndexOf('[');
            int end = path.LastIndexOf(']');
            if (start != -1 && end != -1 && end > start)
            {
                string number = path.Substring(start + 1, end - start - 1);
                if (int.TryParse(number, out int index))
                    return index;
            }

            return -1;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}
