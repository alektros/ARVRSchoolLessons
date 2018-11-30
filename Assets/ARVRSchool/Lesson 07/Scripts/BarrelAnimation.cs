using System.Linq;

namespace Ru.Funreality.ARVRLessons.Lesson07
{
    using UnityEngine;

    public class BarrelAnimation : MonoBehaviour
    {
        [SerializeField] private Renderer[] _barrelRenders;
        [SerializeField] private Color      _startColor;
        [SerializeField] private Color      _endColor;
        private                  Material[] _materials;
        private                  void       Start() { _materials = _barrelRenders.Select(x => x.material).ToArray(); }

        private void Update()
        {
            var color = Color.Lerp(_startColor, _endColor, Mathf.Sin(Time.time));
            foreach (var material in _materials)
            {
                material.SetColor("_Color", color);
            }
        }
    }
}