using System;
using System.Collections.Generic;
using System.Reflection;

namespace CreativeTool.Scripts.Attributes
{
    public static class AttributeFinder
    {
        public static IEnumerable<MethodInfo> TryFindMethods<T>() where T : Attribute
        {
#if UNITY_EDITOR
            return UnityEditor.TypeCache.GetMethodsWithAttribute<T>();
#else
            return new List<MethodInfo>();
#endif
        }
    }
}
