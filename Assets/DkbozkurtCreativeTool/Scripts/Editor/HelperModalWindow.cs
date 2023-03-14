using System;
using System.Collections.Generic;
using System.Linq;
using DkbozkurtCreativeTool.Scripts.Attributes;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Editor
{
    public class HelperModalWindow : EditorWindow
    {
        private Dictionary<KeyCode, string> _shortcutAttributesData = new Dictionary<KeyCode, string>();

        private bool _isInitialScanCalled = false;

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
            if (!_isInitialScanCalled)
            {
                _isInitialScanCalled = true;
                ScanShortcutsAttribute();
            }
            
            GUILayout.Label("SHORTCUTS",EditorStyles.centeredGreyMiniLabel);

            EditorGUILayout.BeginHorizontal();
            
            EditorGUILayout.LabelField("Keys",EditorStyles.boldLabel,GUILayout.Width(60));
            EditorGUILayout.LabelField("Values",EditorStyles.boldLabel);
            
            // EditorGUILayout.LabelField("Keys","Values",EditorStyles.boldLabel);

            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);
            
            for (int i = 0; i < _shortcutAttributesData.Count; i++)
            {
                var element = _shortcutAttributesData.ElementAt(i);
                
                GUILayout.BeginHorizontal(GUI.skin.box);
                
                EditorGUILayout.LabelField(element.Key.ToString(), EditorStyles.whiteLabel, GUILayout.Width(50));
                EditorGUILayout.LabelField(":",EditorStyles.whiteLabel,GUILayout.Width(10));
                EditorGUILayout.LabelField(element.Value.ToString());
                GUILayout.FlexibleSpace();

                GUILayout.EndHorizontal();
            }

            // Pushes elements to the bottom
            GUILayout.FlexibleSpace();
            
            GUILayout.BeginHorizontal();
            
            if (GUILayout.Button("ReScan Attributes"))
            {
                ScanShortcutsAttribute();    
            }
            
            if (GUILayout.Button("Exit"))
            {
                _shortcutAttributesData.Clear();
                Close();
            }
            
            GUILayout.EndHorizontal();
        }
        
        private void ScanShortcutsAttribute()
        {
            _shortcutAttributesData.Clear();
            var iEnumerable = AttributeFinder.TryFindMethods<ShortcutAttribute>();
            ScanThroughMethodsWithIEnumerable(iEnumerable);
        }
        
        private void ScanThroughMethodsWithIEnumerable(IEnumerable<MethodInfo> methodInfos)
        {
            foreach (var child in methodInfos)
            {
                var c = child.GetCustomAttribute<ShortcutAttribute>();
                if ( c != null)
                {
                    _shortcutAttributesData.Add(c.Key,c.Description);
                    // Debug.Log("Key : " + c.Key);
                    // Debug.Log("Description : " + c.Description);
                }
            }
        }
    }
}
