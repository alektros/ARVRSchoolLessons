using System.Collections.Generic;

namespace Ru.Funreality.ARVRLessons.Lesson06
{
    using UnityEngine;

    public class UIController : MonoBehaviour
    {
        [SerializeField] private TowerInfoUI       _towerInfoUi;
        [SerializeField] private LayoutingSampleUI _layoutingSample;

        public void ShowTowerInfo(IEnumerable<ITowerProperty> towerProperties)
        {
            _towerInfoUi.ShowInfo(towerProperties, "Very Dangerous Tower");
        }

        private void Start()
        {
            List<ITowerProperty> properties = new List<ITowerProperty>();
            properties.Add(new TowerProperty<int> {Name    = "Range", Value         = 50});
            properties.Add(new TowerProperty<float> {Name  = "Health Points", Value = 35});
            properties.Add(new TowerProperty<string> {Name = "Damage Type", Value   = "Mage"});
            properties.Add(new TowerProperty<float> {Name  = "Damage Radius", Value = 1.5f});
            properties.Add(new TowerProperty<int> {Name    = "Cost", Value          = 200});

            ShowTowerInfo(properties);

            _towerInfoUi.Close();
            _towerInfoUi.OnBackButton          += delegate(TowerInfoUI ui) { ui.Close(); };
            _layoutingSample.OnOpenButtonClick += delegate { ShowTowerInfo(properties); };
        }
    }
}