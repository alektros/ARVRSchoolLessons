using System;
using System.Linq;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "AR-VR Game/LevelInfo", fileName = "LevelInfo")]
    public class LevelInfoAsset : ScriptableObject
    {
        [SerializeField] [Range(5, 15)] private int           _battleFieldWidth  = 10;
        [SerializeField] [Range(5, 15)] private int           _battleFieldHeight = 10;
        [SerializeField]                private Coordinates[] _wayPoints;
        public int WaveCount;
        public int BattleFieldWidth
        {
            get { return _battleFieldWidth; }
        }
        public int BattleFieldHeight
        {
            get { return _battleFieldHeight; }
        }
        public Coordinates[] WayPoints
        {
            get { return _wayPoints; }
        }

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