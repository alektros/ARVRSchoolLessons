using System.Collections.Generic;
using Ru.Funreality.ARVRLessons.Lesson03;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    /// <summary>
    /// Главный управляющий класс уровня
    /// </summary>
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private LevelConstructor _levelConstructor;
        [SerializeField] private MarkerController _markerController;
        [SerializeField] private LevelInfoAsset   _levelInfo;
        [SerializeField] private Tower[]          _towers;
        private                  List<Tile>       _tiles;
        /// <summary>
        /// 
        /// </summary>
        private readonly         List<Tower>      _anchoredTowers = new List<Tower>();

        private void Start()
        {
            // генерируем уровень на основе LevelInfo
            _tiles = _levelConstructor.Construct(_levelInfo);

            // подписываемся на евенты тайла
            foreach (var tile in _tiles)
            {
                tile.TriggerEnter += OnTileTriggerEnter;
                tile.TriggerExit  += OnTileTriggerExit;
            }

            // подписываемся на евенты башни
            foreach (var tower in _towers)
            {
                tower.OnHealthPointChanged += OnTowerHPChanged;
            }
        }

        private void OnTowerHPChanged(Tower tower, int hp) { }

        private void OnTileTriggerExit(object sender, Tile.TileEventArgs args)
        {
            // временное решение проблемы со срабатыванием коллизий при старте
            if (Time.realtimeSinceStartup < 10) return;
            Debug.Log(string.Format("{0} has trigger exited {1}", args.Tile.name, args.Collider.name));

            var tower = args.Collider.GetComponentInParent<Tower>();
            if (tower != null) // проверяем, что коллизия произошла с башней и устанавливаем ей цвет по молчанию
            {
                tower.SetDefaultColor();
            }
        }

        private void OnTileTriggerEnter(object sender, Tile.TileEventArgs args)
        {
            // временное решение проблемы со срабатыванием коллизий при старте
            if (Time.realtimeSinceStartup < 10) return;
            Debug.Log(string.Format("{0} has trigger enter {1}", args.Tile.name, args.Collider.name));

            var tower = args.Collider.GetComponentInParent<Tower>();
            if (tower != null) // проверяем, что коллизия произошла с башней, отвязываем от маркера и задаем цвет
            {
                var tile = args.Tile;
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