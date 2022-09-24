using UnityEditor;
using UnityEngine;

namespace Utilities
{
    [CustomPropertyDrawer(typeof(EnumOptionShowAttribute))]
    public class EnumOptionShowAttributeDrawer : PropertyDrawer
    {
        private float propertyHeight;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!IsOptionSelected(property, label))
                return;

            label.text = property.displayName;
            EditorGUI.PropertyField(position, property, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return propertyHeight;
        }

        private bool IsOptionSelected(SerializedProperty property, GUIContent label)
        {
            EnumOptionShowAttribute enumAttribute = (EnumOptionShowAttribute)attribute;
            SerializedProperty enumProperty = property.serializedObject.FindProperty(enumAttribute.EnumName);
            string[] options = enumProperty.enumNames;

            bool selectedProperty = options[enumProperty.enumValueIndex] == enumAttribute.OptionName;

            propertyHeight = selectedProperty ? EditorGUI.GetPropertyHeight(property, label) : -EditorGUIUtility.standardVerticalSpacing;

            return selectedProperty;
        }
    }
}
