using System;
using Ru.Funreality.ARVRLessons.Lesson06.EnumerableData;
using UnityEngine;

namespace Ru.Funreality.ARVRLessons.Lesson06
{
    [Serializable]
    public class TowerPropertiesController : EnumerableDataController<ITowerProperty>
    {
        [SerializeField] private TowerPropertyView        _prototype;
        protected override       DataView<ITowerProperty> Prototype { get { return _prototype; } }
    }
}