using System;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    /// <summary>
    /// Компонент позволяюющий передать вверх по иерархии обработку коллизий
    ///
    /// Component allowing to pass the collisions up on the hierarchy
    /// </summary>
    public class TriggerHandler : MonoBehaviour
    {
        #region Events 

        /// <summary>
        /// Вызывается, когда срабатывает OnTriggerEnter
        /// </summary>
        public EventHandler<TriggerHandlerArgs> TriggerEnter = delegate { };
        /// <summary>
        /// Вызывается, когда срабатывает OnTriggerExit
        /// </summary>
        public EventHandler<TriggerHandlerArgs> TriggerExit = delegate { };

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            TriggerEnter(this, new TriggerHandlerArgs {Collider = other});
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerExit(this, new TriggerHandlerArgs {Collider = other});
        }

        public class TriggerHandlerArgs : EventArgs
        {
            public Collider Collider { get; set; }
        }
    }
}