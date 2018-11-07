using System;
using UnityEngine;

namespace Ru.Funreality.ARVRLessons.Lesson03
{
    public class MarkerController : MonoBehaviour
    {
        [SerializeField] private ContentData[] _data;


        // Use this for initialization
        void Start()
        {
            foreach (var handler in _data)
            {
                handler.Handler.OnMarkerFound += OnMarkerFound;
                handler.Handler.OnMarkerLost += OnMarkerLost;
            }
        }


        private void OnMarkerLost(CustomTrackableEventHandler handler)
        {
            Debug.LogWarning("OnMarkerLost " + handler.name);
        }

        private void OnMarkerFound(CustomTrackableEventHandler handler)
        {
            Debug.LogWarning("OnMarkerFound " + handler.gameObject.name);
        }

        private void Update()
        {
            foreach (var handler in _data)
            {
                handler.Update();
            }
        }

        [Serializable]
        public struct ContentData
        {
            public CustomTrackableEventHandler Handler;
            public GameObject Content;

            public void Update()
            {
                Content.transform.position = Handler.transform.position;
                Content.transform.rotation = Handler.transform.rotation;
            }
        }
    }
}