using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ru.Funreality.ARVRLessons.Lesson06
{
    public class LayoutingSampleUI : MonoBehaviour
    {
        [SerializeField] private Button                    _openButton;
        public                   Action<LayoutingSampleUI> OnOpenButtonClick = delegate { };
        public                   void                      Close() { gameObject.SetActive(false); }
        public                   void                      Open()  { gameObject.SetActive(true); }

        private void Start()
        {
            _openButton.onClick.AddListener(delegate { OnOpenButtonClick(this); });
        }
    }
}