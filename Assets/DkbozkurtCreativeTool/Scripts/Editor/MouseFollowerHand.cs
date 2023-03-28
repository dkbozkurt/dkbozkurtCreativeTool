using DkbozkurtCreativeTool.Scripts.Managers;
using UnityEditor;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Editor
{
    public partial class DkbCreativeToolManager : EditorWindow
    {
        private readonly string CANVAS_NAME = "CrvMouseFollowerHandCanvas";
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
            
            if (GameObject.Find(CANVAS_NAME) == null)
            {
                parentCanvas = GenerateNGetCanvas().transform;
            }
            else
            {
                parentCanvas = GameObject.Find(CANVAS_NAME).transform;
            }

            parentCanvas.name = CANVAS_NAME;
            parentCanvas.GetComponent<Canvas>().sortingOrder = 300;
            
            var MouseFollowerHandPrefab =
                AssetDatabase.LoadAssetAtPath<GameObject>(
                    "Assets/DkbozkurtCreativeTool/Prefabs/CreativeMouseFollowerHand.prefab");
            Instantiate(MouseFollowerHandPrefab, parentCanvas);
        }
    }
}
        