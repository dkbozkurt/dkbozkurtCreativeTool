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
    public class CreativeGameManagerTest : MonoBehaviour
    {
        // private void Start()
        // {
        //     var iEnumerable = AttributeFinder.TryFindMethods<ShortcutAttribute>();
        //     ScanThroughMethodsWithIEnumerable(iEnumerable);
        // }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                TestMethod1();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                TestMethod2();
            }
            
            
        }

        [Shortcut(KeyCode.F2,"F2 is the shortcut of TestMethod1!")]
        public void TestMethod1()
        {
            Debug.Log("F2 Keycode Pressed!");
        }

        [Shortcut(KeyCode.Q,"Q is the shortcut of TestMethod2")]
        public void TestMethod2()
        {
            Debug.Log("Q Keycode Pressed!");   
        }
        
        
        
        // private void ScanThroughMethodsWithIEnumerable(IEnumerable<MethodInfo> methodInfos)
        // {
        //     foreach (var child in methodInfos)
        //     {
        //         var c = child.GetCustomAttribute<ShortcutAttribute>();
        //         if ( c != null)
        //         {
        //             Debug.Log("Key : " + c.Key);
        //             Debug.Log("Description : " + c.Description);
        //         }
        //     }
        // }
    }
}
