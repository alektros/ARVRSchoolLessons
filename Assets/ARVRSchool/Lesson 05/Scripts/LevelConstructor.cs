using System.Collections.Generic;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    /// <summary>
    /// TODO
    /// 
    /// About Hex https://www.redblobgames.com/grids/hexagons/#coordinates
    /// 
    /// Algorithms - http://pcg.wikidot.com/category-pcg-algorithms
    /// </summary>
    public class LevelConstructor : MonoBehaviour
    {
        [SerializeField] private GameObject _riverPrefab;
        [SerializeField] private GameObject _grassPrefab;
        [SerializeField] private Transform  _battleFieldRoot;

        public List<Tile> Construct(LevelInfoAsset asset)
        {
            List<Tile> result = new List<Tile>();

            float globalXOffset = -asset.BattleFieldWidth  / 2f;
            float globalZOffset = -asset.BattleFieldHeight / 2f;
            // float globalXOffset = 0;
            // float globalZOffset = 0;
            for (int x = 0; x < asset.BattleFieldWidth; x++)
            {
                for (int z = 0; z < asset.BattleFieldHeight; z++)
                {
                    var   coordinates = new LevelInfoAsset.Coordinates() {x = x, y = z};
                    float xOffset     = (z % 2 == 0) ? 0.5f : 0f;
                    bool  isRiver     = asset.HasPositionInWayPoints(coordinates);
                    var   prefab      = isRiver ? _riverPrefab : _grassPrefab;
                    var instance =
                        Instantiate(prefab,              new Vector3(x + xOffset + globalXOffset, 0, z + globalZOffset),
                                    Quaternion.identity, _battleFieldRoot);
                    instance.name = string.Format("Tile [{0}:{1}]", x, z);
                    var tile = instance.GetComponent<Tile>();
                    tile.Coordinates = coordinates;
                    tile.Type        = isRiver ? Tile.TileType.River : Tile.TileType.Grass;
                    result.Add(tile);
                }
            }

            return result;
        }
    }
}