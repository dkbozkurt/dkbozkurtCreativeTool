using System;
using System.Collections.Generic;
using DkbozkurtCreativeTool.Scripts.Attributes;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Editor
{
    public class HelperModalWindow : EditorWindow
    {
        public string choice = "";

        public static void Open()
        {
            HelperModalWindow helperWindow = CreateInstance<HelperModalWindow>();
            helperWindow.ShowModal();
        }

        public void OnGUI()
        {
            UIVisuals();
        }

        private void UIVisuals()
        {
            GUILayout.Label("Header",EditorStyles.boldLabel);
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Choice");
            choice = GUILayout.TextField(choice);
            GUILayout.EndHorizontal();
            
            GUILayout.Space(20);
            
            if (GUILayout.Button("Scan"))
            {
                var iEnumerable = AttributeFinder.TryFindMethods<ShortcutAttribute>();
                ScanThroughMethodsWithIEnumerable(iEnumerable);    
            }
            
            if (GUILayout.Button("Exit"))
            {
                
                Debug.Log("Choice : " + choice);
                Close();
            }
        }
        
        private void ScanThroughMethodsWithIEnumerable(IEnumerable<MethodInfo> methodInfos)
        {
            foreach (var child in methodInfos)
            {
                var c = child.GetCustomAttribute<ShortcutAttribute>();
                if ( c != null)
                {
                    Debug.Log("Key : " + c.Key);
                    Debug.Log("Description : " + c.Description);
                }
            }
        }
    }
}
