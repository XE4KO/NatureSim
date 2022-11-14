using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NatureSim.Console
{
    class Map
    {
        public int Width => width;
        public int Height => height;
        int time = 0;
        public int Ticks => time;
        private readonly int width;
        private readonly int height;

        private Random _random = Configuration.Random;
        private static readonly IReadOnlyList<Biome> Biomes = new Biome[] {
                new Forest(),
                new Swamp(),
                new Field(),
                new Mountain(),
                new Ocean(),
                new River()
        };

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            GenerateMap();
        }
        public Tile this[int x, int y] => tiles[x, y];

        private Tile[,] tiles;
        private void GenerateMap()
        {
            tiles = new Tile[width, height];
            for (int currentWidth = 0; currentWidth < width; currentWidth++)
            {
                for (int currentHeight = 0; currentHeight < height; currentHeight++)
                {
                    tiles[currentWidth, currentHeight] = new Tile(Biomes[_random.Next(Biomes.Count)]);
                }
            }
        }

        internal FoodData FindFood(int coordsX, int coordsY)
        {
            var animalCurrentTile = tiles[coordsX, coordsY];
            Debug.Write($"Find food at {animalCurrentTile.Biome.GetType().Name} [{coordsX}:{coordsY}]: ");
            return animalCurrentTile.FindFood();
        }

        public int LimitY(int coordsY) => Limit(coordsY, Height);
        public int LimitX(int coordsX) => Limit(coordsX, Width);

        private static int Limit(int coord, int max)
        {
            if (coord >= max)
                return 0;
            if (coord < 0)
                return max - 1;
            return coord;

        }

        public void Update()
        {
            time++;
            foreach (var tile in tiles)
            {
                tile.OnUpdate(time);
            }
        }
    }
}
