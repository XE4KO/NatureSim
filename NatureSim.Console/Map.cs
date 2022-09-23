using System;
using System.Collections.Generic;

namespace NatureSim.Console
{
	class Map
    {
        public int Width => width;
        public int Height => height;
        int ticks = 0;

        private int width;
        private int height;

        private Random random = new Random(1);
        private static readonly IReadOnlyList<Biome> Biomes = new Biome[] {
                new Forest(),
                new Swamp(),
                new Field(),
                new Mountain(),
                new Ocean(),
                new River()
        };

        public Tile this[int x, int y]
        {
            get
            {
                var result = tiles[x, y];
                result.OnUpdate(ticks);
                return result;
            }
        }

        private Tile[,] tiles;
        public void GenerateMap(int width, int height) 
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];
            for (int currentWidth = 0; currentWidth < width; currentWidth++)
            {
                for (int currentHeight = 0; currentHeight < height; currentHeight++)
                {
                    tiles[currentWidth, currentHeight] = new Tile(Biomes[random.Next(Biomes.Count)]);
                }
            }
        }

        public int LimitY(int coordsY) => Limit(coordsY, Height);

        internal int Ticks 
            => ticks;

        public int LimitX(int coordsX) => Limit(coordsX, Width);

        private static int Limit(int coord, int max)
        {
            if (coord > max)
                return 0;
            if (coord < 0)
                return max;
            return coord;

        }

        public void Update()
        {
            ticks++;
            //foreach (var tile in tiles)
            //{
            //    tile.OnUpdate(time);
            //}
        }
    }
}
