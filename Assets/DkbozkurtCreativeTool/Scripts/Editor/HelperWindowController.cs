using DkbozkurtCreativeTool.Scripts.Managers;
using UnityEditor;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Editor
{
    public partial class DkbCreativeToolManager : EditorWindow
    {
        private void CallHelperWindow()
        {
            // var CreativeHelperWindow = Resources.Load<GameObject>("DkbozkurtCreativeToolResources/Prefabs/CRV_HelperWindow");
            var CreativeHelperWindow = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/DkbozkurtCreativeTool/Prefabs/CRV_HelperWindow.prefab");
            GenerateEventSystem();
            
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
