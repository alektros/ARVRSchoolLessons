using System.Collections.Generic;
using Ru.Funreality.ARVRLessons.Lesson03;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    public class LevelController : MonoBehaviour
    {
        [SerializeField] private LevelConstructor _levelConstructor;
        [SerializeField] private MarkerController _markerController;
        [SerializeField] private LevelInfoAsset   _levelInfo;
        [SerializeField]
        private Tower[] _towers;
        private                  List<Tile>       _tiles;
        private List<Tower> _anchoredTowers = new List<Tower>();

        private void Start()
        {
            _tiles = _levelConstructor.Construct(_levelInfo);
            
            
            foreach (var tile in _tiles)
            {
                tile.OnTriggerEntered += OnTileHasTrigger;
                tile.OnTriggerExited  += OnTileHasTriggerExited;
            }


            foreach (var tower in _towers)
            {
                tower.OnHealthPointChaged += OnHealthPointChaged;
            }
        }

        private void OnHealthPointChaged(Tower tower, int hp)
        {
            
        }

        private void OnTileHasTriggerExited(Tile tile, Collider collision)
        {
            if (Time.realtimeSinceStartup < 10) return;
            Debug.Log(string.Format("{0} has trigger exited {1}", tile.name, collision.name));
            
            var tower = collision.GetComponentInParent<Tower>();
            if (tower != null)
            {
                tower.SetDefaultColor();
            }
           
        }

        private void OnTileHasTrigger(Tile tile, Collider collision)
        {
            Debug.Log(string.Format("{0} has trigger enter {1}", tile.name, collision.name));

           
            
            var tower = collision.GetComponentInParent<Tower>();
            if (tower != null)
            {
                if (tile.Type == Tile.TileType.Grass && !_anchoredTowers.Contains(tower))
                {
                    _markerController.SetContentAnchored(tower.gameObject, false);
                    tower.SetErrorColor();
                    tower.SetPosition(tile.Anchor.position);
                    tower.SetRotation(tile.Anchor.rotation);
                    _anchoredTowers.Add(tower);
                }
               
            }
        }
    }
}