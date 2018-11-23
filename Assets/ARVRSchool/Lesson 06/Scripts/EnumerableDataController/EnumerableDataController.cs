using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ru.Funreality.ARVRLessons.Lesson06.EnumerableData
{
    [Serializable]
    public abstract class EnumerableDataController<T> where T : Data
    {
        protected abstract       DataView<T>       Prototype { get; }
        [SerializeField] private RectTransform     _root;
        private readonly         List<DataView<T>> _instances = new List<DataView<T>>();

        public virtual void Fill(IEnumerable<T> data)
        {
            ClearAll();

            if (Prototype == null) return;

            Prototype.Activate(true);

            foreach (var dataItem in data)
            {
                var instance = Object.Instantiate(Prototype);
                instance.Bind(dataItem);
                instance.SetParent(_root);
                _instances.Add(instance);
            }

            Prototype.Activate(false);
        }

        public virtual void ClearAll()
        {
            foreach (var instance in _instances)
                Object.Destroy(instance.gameObject);

            _instances.Clear();
        }

        public void OnEnable()
        {
            if (Prototype == null) return;

            Prototype.Activate(false);
        }
    }
}