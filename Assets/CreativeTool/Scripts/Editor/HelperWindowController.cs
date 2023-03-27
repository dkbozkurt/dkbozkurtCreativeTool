using CreativeTool.Scripts.Managers;
using UnityEditor;
using UnityEngine;

namespace CreativeTool.Scripts.Editor
{
    public partial class CreativeToolManager : EditorWindow
    {
        private void CallHelperWindow()
        {
            var CreativeHelperWindow = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/CreativeTool/Prefabs/CRV_HelperWindow.prefab");

            if(IsActiveInScene(CreativeHelperWindow.name)) return;
            
            Instantiate(CreativeHelperWindow);
        }

        private bool IsActiveInScene(string nameOfHelperWindow)
        {
            if (GameObject.Find(nameOfHelperWindow) != null) return true;
            
            if (GameObject.Find(nameOfHelperWindow+"(Clone)") != null) return true;

            if (FindObjectOfType<CreativeHelperWindowManager>() != null) return true;
            
            return false;
        }
    }
}
