using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ru.Funreality.ARVRLessons.Lesson06
{
    public class TowerInfoUI : MonoBehaviour
    {
        [SerializeField] private Text                      _header;
        [SerializeField] private Button                    _backButton;
        [SerializeField] private TowerPropertiesController _propertiesController;
        public                   Action<TowerInfoUI>       OnBackButton = delegate(TowerInfoUI ui) { };

        public void ShowInfo(IEnumerable<ITowerProperty> towerProperties, string header)
        {
            _propertiesController.Fill(towerProperties);
            _header.text = header;

            gameObject.SetActive(true);
        }

        public  void Close()    { gameObject.SetActive(false); }
        private void Start()    { _backButton.onClick.AddListener(delegate { OnBackButton(this); }); }
        private void OnEnable() { _propertiesController.OnEnable(); }
    }
}