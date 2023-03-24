using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DkbozkurtCreativeTool.Scripts.Editor
{
    public partial class DkbCreativeToolManager : EditorWindow
    {
        private void GenerateCanvas()
        {
            var canvas = new GameObject("Canvas");
            canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            var canvasScaler = canvas.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1125, 2436);
            canvasScaler.matchWidthOrHeight =1f;
            canvas.AddComponent<GraphicRaycaster>();

            if(GameObject.Find("Event System")) return;
            
            var eventSystem = new GameObject("Event System");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
        
        private GameObject GenerateUIObject(string name,Transform parent= null)
        {
            var obj = new GameObject(name);
            obj.AddComponent<RectTransform>();
            if(parent != null) obj.transform.SetParent(parent);
            return obj;
        }

        private void AddImageComponent(GameObject targetObj)
        {
            var image = targetObj.AddComponent<Image>();
            image.raycastTarget = false;
        }

        private void LocateRectTransform(RectTransform rectTransform,Vector2 location,Vector2 size)
        {
            rectTransform.anchoredPosition = location;
            rectTransform.sizeDelta = size;
        }

        private bool IsGameObjectAlreadyExistInScene(string gameObjectName)
        {
            if (!GameObject.Find(gameObjectName)) return false;
            
            Debug.LogWarning(gameObjectName + " already exist in the scene!");
            return true;
        }
        
        private void SetComponentAsLastChild(RectTransform focusObj)
        {
            if(GameObject.Find("Canvas") == null) return;

            focusObj.SetAsLastSibling();
        }

        private void SetComponentAsFirstChild(RectTransform focusObj)
        {
            if(GameObject.Find("Canvas") == null) return;
            
            focusObj.SetAsFirstSibling();
        }
    }
}
