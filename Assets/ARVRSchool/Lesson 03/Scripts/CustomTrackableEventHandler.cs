using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

namespace Ru.Funreality.ARVRLessons.Lesson03
{
    public class CustomTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
    {
        private TrackableBehaviour _trackableBehaviour;

        public Action<CustomTrackableEventHandler> OnMarkerFound = delegate(CustomTrackableEventHandler handler) { };
        public Action<CustomTrackableEventHandler> OnMarkerLost = delegate(CustomTrackableEventHandler handler) { };


        protected virtual void Start()
        {
            _trackableBehaviour = GetComponent<TrackableBehaviour>();
            if (_trackableBehaviour)
                _trackableBehaviour.RegisterTrackableEventHandler(this);
        }

        protected virtual void OnDestroy()
        {
            if (_trackableBehaviour)
                _trackableBehaviour.UnregisterTrackableEventHandler(this);
        }

        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnMarkerFound(this);
            }
            else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                     newStatus == TrackableBehaviour.Status.NO_POSE)
            {
                OnMarkerLost(this);
            }
            else
            {
                OnMarkerLost(this);
            }
        }
    }
}