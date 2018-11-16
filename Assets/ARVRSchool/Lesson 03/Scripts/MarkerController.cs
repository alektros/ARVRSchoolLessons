using System;
using System.Linq;
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
                handler.Handler.OnMarkerLost  += OnMarkerLost;
            }
        }

        public void SetContentAnchored(GameObject go, bool anchored)
        {
           var contentData = _data.First(x => x.Content == go);
            if (contentData != null)
            {
                contentData.Anchored = anchored;
            }
        }

        private void OnMarkerLost(CustomTrackableEventHandler handler)
        {
            Debug.LogWarning("OnMarkerLost " + handler.name);
            _data.First(x => x.Handler == handler).Content.SetActive(false);
        }

        private void OnMarkerFound(CustomTrackableEventHandler handler)
        {
            Debug.LogWarning("OnMarkerFound " + handler.gameObject.name);
            _data.First(x => x.Handler == handler).Content.SetActive(true);
        }

        private void Update()
        {
            foreach (var handler in _data)
            {
                handler.Update();
            }
        }

        [Serializable]
        public class ContentData
        {
            public CustomTrackableEventHandler Handler;
            public GameObject                  Content;

            public bool Anchored;

           
            
            public void Update()
            {
                if (Anchored)
                {
                    Content.transform.position = Handler.transform.position;
                    Content.transform.rotation = Handler.transform.rotation;
                }
              
            }
        }
    }
}