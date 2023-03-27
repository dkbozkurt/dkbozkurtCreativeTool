using UnityEditor;
using UnityEngine;

namespace CreativeTool.Scripts.Editor
{
    public partial class CreativeToolManager : EditorWindow
    {
        private GameObject _creativeParentCanvas;

        [MenuItem("Tools/CreativeTool")]
        public static void ShowWindow()
        {
            var window = GetWindow<CreativeTool.Scripts.Editor.CreativeToolManager>(typeof(SceneView));
            SetEditorIcon(window);
        }

        private void OnGUI()
        {
            UIVisuals();
        }

        private static void SetEditorIcon(CreativeTool.Scripts.Editor.CreativeToolManager window)
        {
            // If you want to get texture from url follow below steps
            // var url = "file://C:/Users/PTN-DOGUKAN/Downloads/asd.png";
            // WWW _texture= new WWW(url);
            // var texture = _texture.texture;

            var texture = AssetDatabase.LoadAssetAtPath<Texture>("Assets/CreativeTool/Textures/CreativeToolIcon.png");

            window.titleContent = new GUIContent("Creative Tool", texture,
                "Helpful tool for developing creative game contents for games.");
        }

        private void UIVisuals()
        {
            GUILayout.Space(10);
            HelperModal();
            
            EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);
            
            HelperWindow();
            
            EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);
            
            UIMouseFollowerHand();
            
            EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);
            
            // Check's if project in game mode, so you can avoid showing editor time purposed buttons. !!!
            // if(!Application.isPlaying)             
            //     EditorGUILayout.LabelField("Dogukan",EditorStyles.boldLabel); 
        }
        
        private void HelperModal()
        {
            GUILayout.BeginHorizontal();
            
            GUILayout.Label("Helper Modal Window",EditorStyles.boldLabel);
            
            if (GUILayout.Button("Helper Modal Window Call",GUILayout.Width(200),GUILayout.Height(25)))
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
        }

        private void UIMouseFollowerHand()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Mouse Follower Hand",EditorStyles.boldLabel);
            
            if (GUILayout.Button("Import Mouse Follower Hand",GUILayout.Width(200),GUILayout.Height(25)))
            {
                CallMouseFollowerHand();
            }
            
            GUILayout.EndHorizontal();
        }
    }
}
