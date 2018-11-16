using System;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    public class Tile : MonoBehaviour
    {
        public Transform Anchor;
        public                   LevelInfoAsset.Coordinates Coordinates { get; set; }
        public                   TileType                   Type        { get; set; }
        
        public                   Action<Tile, Collider>     OnTriggerEntered = delegate { };
        public                   Action<Tile, Collider>     OnTriggerExited  = delegate { };
        
        
        
        [SerializeField] private TriggerHandler             _handler;

        public enum TileType
        {
            River,
            Grass
        }

        private void Awake()
        {
            _handler.OnTriggerEntered += delegate(Collider collision) { OnTriggerEntered(this, collision); };
            _handler.OnTriggerExited  += delegate(Collider collision) { OnTriggerExited(this, collision); };
        }
    }
}