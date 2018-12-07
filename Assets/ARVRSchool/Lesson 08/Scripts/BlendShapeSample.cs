namespace Ru.Funreality.ARVRLessons.Lesson08
{
    using UnityEngine;

    public class BlendShapeSample : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
        [SerializeField] private float               _speed = 1f;

        private void Update()
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(0, Mathf.PingPong(Time.time, 1f) * 100 * _speed);
        }
    }
}