using System;
using UnityEngine;

namespace CreativeTool.Scripts.Attributes
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false, Inherited = true)]
    public class CreativeShortcutAttribute : Attribute
    {
        public KeyCode Key = KeyCode.None;
        public string Description = String.Empty;

        public CreativeShortcutAttribute(KeyCode key, string description)
        {
            Key = key;
            Description = description;
        }
    }
}
