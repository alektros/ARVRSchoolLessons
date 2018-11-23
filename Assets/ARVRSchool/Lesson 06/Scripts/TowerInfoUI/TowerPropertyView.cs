using Ru.Funreality.ARVRLessons.Lesson06.EnumerableData;
using UnityEngine;
using UnityEngine.UI;

namespace Ru.Funreality.ARVRLessons.Lesson06
{
    public class TowerPropertyView : DataView<ITowerProperty>
    {
        [SerializeField] private Text _propertyNameText;
        [SerializeField] private Text _propertyValueText;

        public override void Bind(ITowerProperty data)
        {
            base.Bind(data);
            _propertyNameText.text  = data.Name;
            _propertyValueText.text = data.RawValue.ToString();
        }
    }
}