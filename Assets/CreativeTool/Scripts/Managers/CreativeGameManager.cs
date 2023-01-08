// Dogukna Kaan Bozkurt
//      github.com/dkbozkurt

using System;
using System.Linq;
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
            var x = AttributeFinder.TryFindMethods<ShortcutAttribute>();
            // Debug.Log("x count : "+ x.Count());
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

        private void ExternalDebug()
        {
            
        }
    }
}
