// Dogukan Kaan Bozkurt
//      github.com/dkbozkurt

using System;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Attributes
{
    /// <summary>
    /// Ref : https://answers.unity.com/questions/1304894/how-to-write-a-custom-attribute.html
    /// </summary>
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false, Inherited = true)]
    public class ShortcutAttribute : Attribute
    {
        public KeyCode Key = KeyCode.None;
        public string Description = String.Empty;

        public ShortcutAttribute(KeyCode key, string description)
        {
            Key = key;
            Description = description;
        }
    }
}
