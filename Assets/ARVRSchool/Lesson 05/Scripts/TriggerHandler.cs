using System;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    public class TriggerHandler : MonoBehaviour
    {
        public Action<Collider> OnTriggerEntered = delegate(Collider collider) { };
        public Action<Collider> OnTriggerExited  = delegate(Collider collider) { };

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEntered(other);
        }

        private void OnTriggerExit(Collider other)
        {
            OnTriggerExited(other);
        }
    }
}