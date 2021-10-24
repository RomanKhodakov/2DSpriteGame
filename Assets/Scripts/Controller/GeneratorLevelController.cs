using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Test2DGame
{
    public class GeneratorLevelController : IInitialization
    {
        private const int CountWall = 4;

        private readonly List<Tilemap> _tileMaps;
        private readonly List<Tile> _tiles;
        private readonly int _widthMap;
        private readonly int _heightMap;
        private readonly int _factorSmooth;
        private readonly int _randomFillPercent;
        private readonly int[,] _map;

        public GeneratorLevelController(GenerateLevelView generateLevelView)
        {
            _tileMaps = generateLevelView.TileMaps;
            _tiles = generateLevelView.Tiles;
            _widthMap = generateLevelView.WidthMap;
            _heightMap = generateLevelView.HeightMap;
            _factorSmooth = generateLevelView.FactorSmooth;
            _randomFillPercent = generateLevelView.RandomFillPercent;

            _map = new int[_widthMap, _heightMap];
        }

        public void Initialization()
        {
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            RandomFillLevel();

            for (var i = 0; i < _factorSmooth; i++)
                SmoothMap();

            DrawTilesOnMap();
        }

        private void RandomFillLevel()
        {
            var seed = Time.time.GetHashCode();
            var pseudoRandom = new System.Random(seed);

            for (var x = 0; x < _widthMap; x++)
            {
                for (var y = 0; y < _heightMap; y++)
                {
                    if (x == 0 || x == _widthMap - 1 || y == 0 || y == _heightMap - 1)
                        _map[x, y] = 2;
                    else
                        _map[x, y] = (pseudoRandom.Next(0, 100) < _randomFillPercent) ? 1 : 0;
                }
            }
        }

        private void SmoothMap()
        {
            for (var x = 1; x < _widthMap - 1; x++)
            {
                for (var y = 1; y < _heightMap - 1; y++)
                {
                    var neighbourWallTiles = GetSurroundingWallCount(x, y);

                    if (neighbourWallTiles > CountWall)
                        _map[x, y] = 1;
                    else if (neighbourWallTiles < CountWall)
                        _map[x, y] = 0;
                }
            }
        }


        private int GetSurroundingWallCount(int gridX, int gridY)
        {
            var wallCount = 0;

            for (var neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
            {
                for (var neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                        wallCount += _map[neighbourX, neighbourY] == 1 ? 1 : 0;
                }
            }

            return wallCount;
        }


        private void DrawTilesOnMap()
        {
            if (_map == null)
                return;

            for (var x = 0; x < _widthMap; x++)
            {
                for (var y = 0; y < _heightMap; y++)
                {
                    var positionTile = new Vector3Int(-_widthMap / 2 + x, -_heightMap / 2 + y, 0);

                    switch (_map[x, y])
                    {
                        case 1:
                            _tileMaps[0].SetTile(positionTile, _tiles[0]);
                            break;
                        case 2:
                            _tileMaps[1].SetTile(positionTile, _tiles[1]);
                            break;
                    }
                }
            }
        }
    }
}