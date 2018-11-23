using System;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    /// <summary>
    /// Компонент, управляющий одним тайлом игрового поля
    /// </summary>
    public class Tile : MonoBehaviour
    {
        [SerializeField] private TriggerHandler             _handler;
        public                   Transform                  Anchor;
        public                   LevelInfoAsset.Coordinates Coordinates { get; set; }
        public                   TileType                   Type        { get; set; }

        #region Events 

        public EventHandler<TileEventArgs> TriggerEnter = delegate { };
        public EventHandler<TileEventArgs> TriggerExit  = delegate { };

        #endregion

        /// <summary>
        /// Тип тайла - река или трава
        /// </summary>
        public enum TileType
        {
            River,
            Grass
        }

        private void Awake()
        {
            // Подписываемся на евенты дочернего обработчика и передаем вверх по иерархии
            _handler.TriggerEnter += (sender, args) =>
                                         TriggerEnter(this, new TileEventArgs {Tile = this, Collider = args.Collider});
            _handler.TriggerExit += (sender, args) =>
                                        TriggerExit(this, new TileEventArgs {Tile = this, Collider = args.Collider});
        }

        public class TileEventArgs : EventArgs
        {
            public Tile     Tile     { get; set; }
            public Collider Collider { get; set; }
        }
    }
}