using DkbozkurtCreativeTool.Scripts.Managers;
using UnityEditor;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Editor
{
    public partial class DkbCreativeToolManager : EditorWindow
    {
        private void CallMouseFollowerHand()
        {
            if (PreChecker()) return;

            if (GameObject.Find("Canvas") == null)
            {
                GenerateCanvas();
            }
            
        }
        
        private bool PreChecker()
        {
            if (FindObjectOfType<CreativeUIManager>() != null) return true;

            return false;
        }
    }
}
        