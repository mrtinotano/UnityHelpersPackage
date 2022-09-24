using UnityEngine;
using UnityEditor;

namespace Utilities
{
    [CustomPropertyDrawer(typeof(SceneAttribute))]
    public class SceneDrawer : PropertyDrawer
    {
        private float propertyHeight;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                propertyHeight = -EditorGUIUtility.standardVerticalSpacing;
                Debug.LogError($"{property.name} is not a string");
                return;
            }

            SceneAsset sceneAsset = null;

            if (!string.IsNullOrEmpty(property.stringValue))
                sceneAsset = GetSceneAsset(property.stringValue);

            Object scene = EditorGUI.ObjectField(position, label, sceneAsset, typeof(SceneAsset), true);
            property.stringValue = (scene == null) ? string.Empty : scene.name;
        }

        protected SceneAsset GetSceneAsset(string sceneName)
        {
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (scene.path.IndexOf($"{sceneName}.unity") != -1)
                {
                    return AssetDatabase.LoadAssetAtPath(scene.path, typeof(SceneAsset)) as SceneAsset;
                }
            }

            return null;
        }
    }
}
