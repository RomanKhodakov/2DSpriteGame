using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Test2DGame
{
    public class GenerateLevelView : MonoBehaviour
    {
        [SerializeField]
        private List<Tilemap> _tileMaps;
  
        [SerializeField]
        private List<Tile> _tiles;
  
        [SerializeField]
        private int _widthMap;

        [SerializeField]
        private int _heightMap;
  
        [SerializeField]
        private int _factorSmooth;

        [SerializeField] [Range(0, 100)]
        private int _randomFillPercent;
  
        public List<Tilemap> TileMaps => _tileMaps;
  
        public List<Tile> Tiles => _tiles;
  
        public int WidthMap => _widthMap;
  
        public int HeightMap => _heightMap;
  
        public int FactorSmooth => _factorSmooth;
  
        public int RandomFillPercent => _randomFillPercent;
    }
}
