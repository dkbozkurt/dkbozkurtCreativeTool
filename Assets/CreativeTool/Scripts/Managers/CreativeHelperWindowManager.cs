using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CreativeTool.Scripts.Attributes;
using TMPro;
using UnityEngine;

namespace CreativeTool.Scripts.Managers
{
    public class CreativeHelperWindowManager : MonoBehaviour
    {
        [Header("Changeable Properties")]
        public bool InitializeOnStart = true;

        [Multiline] [SerializeField] private string _devNotes = "If you are having any sort of unexpected problem. Mind Clear All playerPrefs.";

        [Header("Inner Properties")]
        [SerializeField] private GameObject _helperWindowBackground;
        [Space]
        [SerializeField] private GameObject _devNotesBackground;
        [SerializeField] private TextMeshProUGUI _devNotesTextZone;
        [Space]
        [SerializeField] private TextMeshProUGUI _keyValueTextZone;

        [Space] 
        [SerializeField] private TextMeshProUGUI _footerMainText;
        [SerializeField] private TextMeshProUGUI _footerSignatureText;

        private Dictionary<KeyCode, string> _shortcutAttributesData = new Dictionary<KeyCode, string>();
        private bool _isHelperWindowActive;
        
        private void Awake()
        {
            Close();
            _isHelperWindowActive = InitializeOnStart;
            SetFooterText();
        }

        private void Start()
        {
            if (InitializeOnStart)
                Open();

            SetDeveloperNotes();
            
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

        [CreativeShortcut(KeyCode.F1,"Toggle Creative Helper Window")]
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

        private void SetDeveloperNotes()
        {
            if (_devNotes == "")
            {
                _devNotesBackground.SetActive(false);
                return;
            }
            _devNotesTextZone.text = "<color=\"red\">Developer Notes:\n</color>" + "<color=#DEDEDE>" + _devNotes + "</color>";
        }
        
        private void SetKeysAndValues()
        {
            _keyValueTextZone.text = "<color=\"yellow\">SHORTCUTS:</color>\n";

            for (int i = 0; i < _shortcutAttributesData.Count; i++)
            {
                var element = _shortcutAttributesData.ElementAt(i);

                _keyValueTextZone.text += "<color=\"green\">" + element.Key.ToString() + " : </color><color=\"white\">" 
                    + element.Value.ToString() +"</color>\n";
            }
        }

        private void SetFooterText()
        {
            _footerMainText.text = "F1 to toggle helper window.";
            _footerSignatureText.text = "<color=\"black\"></color>";
        }
        

        private void ScanShortcutsAttribute()
        {
            _shortcutAttributesData.Clear();
            var iEnumerable = AttributeFinder.TryFindMethods<CreativeShortcutAttribute>();
            ScanThroughMethodsWithIEnumerable(iEnumerable);
        }
        
        private void ScanThroughMethodsWithIEnumerable(IEnumerable<MethodInfo> methodInfos)
        {
            foreach (var child in methodInfos)
            {
                var c = child.GetCustomAttribute<CreativeShortcutAttribute>();
                if ( c != null)
                {
                    _shortcutAttributesData.Add(c.Key,c.Description);
                }
            }
            SetKeysAndValues(); 
        }
    }
}
