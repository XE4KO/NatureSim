﻿using System;
using System.Collections.Generic;

namespace NatureSim.Console
{
	class Map
    {
        public int Width => width;
        public int Height => height;

        private int width;
        private int height;

        private Random random = new Random();
        private readonly IReadOnlyList<Biome> biomes = new Biome[] {
                new Forest(),
                new Swamp(),
                new Field(),
                new Mountain(),
                new Ocean(),
                new River()
        };

        public Biome this[int x,int y] => tiles[x,y];

        private Biome[,] tiles;
        public void GenerateMap(int width, int height) 
        {
            this.width = width;
            this.height = height;
            tiles = new Biome[width, height];
            for (int currentWidth = 0; currentWidth < width; currentWidth++)
            {
                for (int currentHeight = 0; currentHeight < height; currentHeight++)
                {
                    tiles[currentWidth, currentHeight] = biomes[random.Next(biomes.Count)];
                }
            }
        }

        public int LimitY(int coordsY) => Limit(coordsY, Height);
        public int LimitX(int coordsX) => Limit(coordsX, Width);

        private static int Limit(int coord, int max)
        {
            if (coord > max)
                return 0;
            if (coord < 0)
                return max;
            return coord;

        }
    }
}
