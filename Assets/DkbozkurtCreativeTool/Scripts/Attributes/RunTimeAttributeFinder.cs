// Dogukna Kaan Bozkurt
//      github.com/dkbozkurt

using System;
using System.Reflection;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Attributes
{
    /// <summary>
    /// Ref : https://answers.unity.com/questions/1304894/how-to-write-a-custom-attribute.html
    /// </summary>
    public class RunTimeAttributeFinder : MonoBehaviour
    {
        private void Start()
        {
            FindAttributes();
        }

        private void FindAttributes()
        {
            MonoBehaviour[] sceneActive = FindObjectsOfType<MonoBehaviour>();

            foreach (var mono in sceneActive)
            {
                MethodInfo[] objectMethods = mono.GetType().GetMethods(BindingFlags.Instance |
                                                                       BindingFlags.Public);
                for (int i = 0; i < objectMethods.Length; i++)
                {
                    CreativeShortcutAttribute creativeShortcutAttribute = Attribute.GetCustomAttribute(objectMethods[i],
                        typeof(CreativeShortcutAttribute)) as CreativeShortcutAttribute;

                    if (creativeShortcutAttribute != null)
                    {
                        Debug.Log("Key Value : " + creativeShortcutAttribute.Key.ToString());
                        Debug.Log("Description Value : " + creativeShortcutAttribute.Description);
                        Debug.Log("Name of the method with attribute : " + objectMethods[i].Name);
                    }
                }
            }
        }

    }
}
