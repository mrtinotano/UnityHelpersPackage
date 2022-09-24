using UnityEngine;
using UnityEditor;

namespace Utilities
{
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public class ConditionalHideAttributeDrawer : PropertyDrawer
    {
        private float propertyHeight;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!IsPropertyEnabled(property, label))
                return;

            EditorGUI.PropertyField(position, property, label, true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return propertyHeight;
        }

        private bool IsPropertyEnabled(SerializedProperty property, GUIContent label)
        {
            ConditionalHideAttribute hideAttribute = (ConditionalHideAttribute)attribute;
            bool enabled  = property.serializedObject.FindProperty(hideAttribute.ConditionalName).boolValue;

            propertyHeight = enabled ? EditorGUI.GetPropertyHeight(property, label) : -EditorGUIUtility.standardVerticalSpacing;

            return enabled;
        }
    }
}
