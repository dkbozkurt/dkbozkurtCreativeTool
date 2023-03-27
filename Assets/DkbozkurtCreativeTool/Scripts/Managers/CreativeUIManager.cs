using System;
using DG.Tweening;
using DkbozkurtCreativeTool.Scripts.Attributes;
using UnityEngine;

namespace DkbozkurtCreativeTool.Scripts.Managers
{
    public class CreativeUIManager : MonoBehaviour
    {
        [Header("Hand Images")] 
        [SerializeField] private Transform _handImagesParent;
        [SerializeField] private GameObject[] _handImages;

        private bool _isCursorOn;
        private int _lastActivatedMouseImageIndex;

        private void Awake()
        {
            _isCursorOn = true;
            _lastActivatedMouseImageIndex = 0;
            
            _handImagesParent.gameObject.SetActive(false);

            for (int i = 0; i < _handImages.Length; i++)
            {
                _handImages[i].SetActive(_lastActivatedMouseImageIndex == i);
            }
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetCursorVisibility();
            }
            
            if(_isCursorOn) return;
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangeHandImage();
            }
            
            FollowMouse();

            if (Input.GetMouseButtonDown(0))
            {
                AnimateFollowerClicked(true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                AnimateFollowerClicked(false);
            }
        }
        
        private void SetCursorVisibility()
        {
            _isCursorOn = !_isCursorOn;
            Cursor.visible = _isCursorOn;
            _handImagesParent.gameObject.SetActive(!_isCursorOn);
        }
        
        private void ChangeHandImage()
        {
            _lastActivatedMouseImageIndex++;
            
            if (_lastActivatedMouseImageIndex >= _handImages.Length) { _lastActivatedMouseImageIndex = 0; }

            for (int i = 0; i < _handImages.Length; i++)
            {
                _handImages[i].SetActive(i == _lastActivatedMouseImageIndex);
            }

        }
        
        private void AnimateFollowerClicked(bool status)
        {
            _handImagesParent.DOKill();

            if (status)
            {
                _handImagesParent.DOScale(Vector3.one * 0.8f, 0.1f).SetEase(Ease.Linear);
            }
            else
            {
                _handImagesParent.DOScale(Vector3.one, 0.1f).SetEase(Ease.Linear);
            }
        }

        private void FollowMouse()
        {
            transform.position = Input.mousePosition;
        }
        
    }
}
