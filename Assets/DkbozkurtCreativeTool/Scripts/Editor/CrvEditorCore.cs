// Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

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
            // If you want to get texture from url follow below steps
            // var url = "file://C:/Users/PTN-DOGUKAN/Downloads/asd.png";
            // WWW _texture= new WWW(url);
            // var texture = _texture.texture;
            
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
            
            // Check's if project in game mode, so you can avoid showing editor time purposed buttons. !!!
            if(!Application.isPlaying)             
                EditorGUILayout.LabelField("Dogukan",EditorStyles.boldLabel);
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
