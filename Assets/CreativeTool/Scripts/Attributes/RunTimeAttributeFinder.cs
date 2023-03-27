using System;
using System.Reflection;
using UnityEngine;

namespace CreativeTool.Scripts.Attributes
{
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
