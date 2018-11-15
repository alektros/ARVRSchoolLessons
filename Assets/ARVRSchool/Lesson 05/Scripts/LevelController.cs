using System.Collections.Generic;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    public class LevelController : MonoBehaviour
    {
        [SerializeField] private LevelConstructor _levelConstructor;
        [SerializeField] private LevelInfoAsset   _levelInfo;
        private                  List<Tile>       _tiles;

        private void Start()
        {
            _tiles = _levelConstructor.Construct(_levelInfo);
            foreach (var tile in _tiles)
            {
                tile.OnTriggerEntered += OnTileHasTrigger;
                tile.OnTriggerExited  += OnTileHasTriggerExited;
            }
        }

        private void OnTileHasTriggerExited(Tile tile, Collider collision)
        {
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
                tower.SetErrorColor();
            }
        }
    }
}