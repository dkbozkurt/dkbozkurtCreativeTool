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
            
            CreateMouseFollowerHand();
        }
        
        private bool PreChecker()
        {
            if (FindObjectOfType<CreativeUIManager>() != null) return true;

            return false;
        }

        private void CreateMouseFollowerHand()
        {
            Transform parentCanvas;
            
            if (GameObject.Find("Canvas") == null)
            {
                parentCanvas = GenerateNGetCanvas().transform;
            }
            else
            {
                parentCanvas = GameObject.Find("Canvas").transform;
            }

            var MouseFollowerHandPrefab =
                AssetDatabase.LoadAssetAtPath<GameObject>(
                    "Assets/DkbozkurtCreativeTool/Prefabs/CreativeMouseFollowerHand.prefab");
            Instantiate(MouseFollowerHandPrefab, parentCanvas);
        }
    }
}
        