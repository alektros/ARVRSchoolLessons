namespace Ru.Funreality.ARVRLessons.Lesson06
{
    using UnityEngine;

    public class SimpleRotation : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotationValue = Vector3.up;
        [SerializeField] private float   _speed         = 1f;

        private void Update()
        {
            transform.rotation *= Quaternion.Euler(_rotationValue * _speed * Time.deltaTime);
        }
    }
}