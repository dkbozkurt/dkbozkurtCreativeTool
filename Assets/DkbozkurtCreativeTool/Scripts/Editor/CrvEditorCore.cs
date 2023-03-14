// Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

using System;
using UnityEditor;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Editor
{
    /// <summary>
    /// Ref : 
    /// </summary>
    public partial class DkbCreativeToolManager : EditorWindow
    {
        private GameObject _creativeParentCanvas;

        [MenuItem("Tools/Dkbozkurt/CreativeTool")]
        public static void ShowWindow()
        {
            var window = GetWindow<DkbCreativeToolManager>(typeof(SceneView));
            SetEditorIcon(window);
        }

        private void OnGUI()
        {
            UIVisuals();
        }

        private static void SetEditorIcon(DkbCreativeToolManager window)
        {
            var texture = Resources.Load<Texture>("DkbozkurtCreativeToolResources/Textures/dkbozkurtIcon");
            window.titleContent = new GUIContent("Creative Tool", texture,
                "Helpful tool for developing creative game contents for games.");
        }

        private void UIVisuals()
        {
            HelperModal();
            
            EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);
            
            HelperWindow();
            
            EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);
            
            
        }
        
        private void HelperModal()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Helper Modal Window",EditorStyles.boldLabel);
            
            if (GUILayout.Button("Trigger Helper Modal Window",GUILayout.Width(200),GUILayout.Height(25)))
            {
                HelperModalWindow.Open();
            }
            
            GUILayout.EndHorizontal();
        }

        private void HelperWindow()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Helper Window",EditorStyles.boldLabel);
            
            if (GUILayout.Button("Import Helper Window",GUILayout.Width(200),GUILayout.Height(25)))
            {
                CallHelperWindow();
            }
            
            GUILayout.EndHorizontal();
            _initializeOnStart = EditorGUILayout.Toggle("Initialize On Start", _initializeOnStart);
        }
    }
}
