using System;
using System.Linq;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    /// <summary>
    /// Ассет, хранящий информацию для генерации уровня
    /// </summary>
    [CreateAssetMenu(menuName = "AR-VR Game/LevelInfo", fileName = "LevelInfo")]
    public class LevelInfoAsset : ScriptableObject
    {
        [SerializeField] [Range(5, 15)] private int           _battleFieldWidth  = 10;
        [SerializeField] [Range(5, 15)] private int           _battleFieldHeight = 10;
        [SerializeField]                private Coordinates[] _wayPoints;
        [SerializeField]                private int           _waveCount;
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        public int BattleFieldWidth
        {
            get { return _battleFieldWidth; }
        }
        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public int BattleFieldHeight
        {
            get { return _battleFieldHeight; }
        }
        /// <summary>
        /// Координаты реки
        /// </summary>
        public Coordinates[] WayPoints
        {
            get { return _wayPoints; }
        }
        /// <summary>
        /// Количество волн врагов
        /// </summary>
        public int WaveCount
        {
            get { return _waveCount; }
        }

        /// <summary>
        /// Проверяет, являются ли данный координаты, координатами реки
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public bool HasPositionInWayPoints(Coordinates coordinates)
        {
            return _wayPoints.Contains(coordinates);
        }

        [Serializable]
        public struct Coordinates
        {
            public int x;
            public int y;
        }
    }
}