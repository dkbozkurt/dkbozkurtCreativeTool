// Dogukna Kaan Bozkurt
//      github.com/dkbozkurt

using System.Collections.Generic;
using System.Reflection;
using DkbozkurtCreativeTool.Scripts.Attributes;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Managers
{
    /// <summary>
    /// Ref:
    /// </summary>
    public class CreativeGameManager : MonoBehaviour
    {
        private void Start()
        {
            var iEnumerable = AttributeFinder.TryFindMethods<ShortcutAttribute>();
            ScanThroughMethodsWithIEnumerable(iEnumerable);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Debugger();
            }
        }

        [Shortcut(KeyCode.F1,"F1 is the shortcut of bla bla!")]
        public void Debugger()
        {
            Debug.Log("F1 Pressed!");
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
