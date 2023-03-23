using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DkbozkurtCreativeTool.Scripts.Attributes;
using TMPro;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Managers
{
    public class CreativeHelperWindowManager : MonoBehaviour
    {
        [Header("Changeable Properties")]
        public bool InitializeOnStart = true;

        [Header("Inner Properties")]
        [SerializeField] private GameObject _helperWindowBackground;
        [SerializeField] private TextMeshProUGUI _keysTextZone;
        [SerializeField] private TextMeshProUGUI _valuesTextZone ;

        private Dictionary<KeyCode, string> _shortcutAttributesData = new Dictionary<KeyCode, string>();
        private bool _isHelperWindowActive;
        
        private void Awake()
        {
            Close();
            _isHelperWindowActive = InitializeOnStart;
        }

        private void Start()
        {
            if (InitializeOnStart)
                Open();

            ScanShortcutsAttribute();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if (_isHelperWindowActive) Close();
                else Open();
            }
        }

        [Shortcut(KeyCode.F1,"Toggle Creative Helper Window")]
        public void Open()
        {
            _helperWindowBackground.gameObject.SetActive(true);
            _isHelperWindowActive = true;
        }

        public void Close()
        {
            _helperWindowBackground.gameObject.SetActive(false);
            _isHelperWindowActive = false;
        }

        private void SetKeysAndValues()
        {
            for (int i = 0; i < _shortcutAttributesData.Count; i++)
            {
                var element = _shortcutAttributesData.ElementAt(i);

                _keysTextZone.text += element.Key.ToString() + " :\n";
                _valuesTextZone.text += " " + element.Value.ToString() + "\n";
            }
        }

        private void ScanShortcutsAttribute()
        {
            _shortcutAttributesData.Clear();
            var iEnumerable = AttributeFinder.TryFindMethods<ShortcutAttribute>();
            ScanThroughMethodsWithIEnumerable(iEnumerable);
        }
        
        private void ScanThroughMethodsWithIEnumerable(IEnumerable<MethodInfo> methodInfos)
        {
            foreach (var child in methodInfos)
            {
                var c = child.GetCustomAttribute<ShortcutAttribute>();
                if ( c != null)
                {
                    _shortcutAttributesData.Add(c.Key,c.Description);
                }
            }
            SetKeysAndValues(); 
        }
    }
}
