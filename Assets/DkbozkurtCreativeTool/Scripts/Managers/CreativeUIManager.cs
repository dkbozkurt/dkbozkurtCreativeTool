using System;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Managers
{
    public class CreativeUIManager : MonoBehaviour
    {
        // TODO this script has to be edited !!!
        [Header("Hand Images")] 
        [SerializeField] private GameObject[] _handImages;

        private bool _isMouseFollowerHandActive = false;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                
            }

        }

        private void MouseFollowerHandSetter()
        {
            
        }

        private void ChangeHandImage()
        {
            
        }
        
        
    }
}
