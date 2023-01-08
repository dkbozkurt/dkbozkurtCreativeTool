// Dogukna Kaan Bozkurt
//      github.com/dkbozkurt

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CreativeTool.Scripts.Attributes;
using UnityEngine;

namespace CreativeTool.Scripts.Managers
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

            // var attributeList = iEnumerable.ToList();
            // ScanThroughList(attributeList);
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Debugger();
            }
        }

        [ShortcutAttribute(KeyCode.F1,"Selammm")]
        public void Debugger()
        {
            Debug.Log("F1 Pressed!");
        }

        private void ScanThroughList(List<MethodInfo> list)
        {
            foreach (var child in list)
            {
                var c = child.GetCustomAttribute<ShortcutAttribute>();
                if ( c != null)
                {
                    Debug.Log("Key : " + c.Key);
                    Debug.Log("Description : " + c.Description);
                }
            }
        }
        
        private void ScanThroughMethodsWithIEnumerable(IEnumerable<MethodInfo> list)
        {
            foreach (var child in list)
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
