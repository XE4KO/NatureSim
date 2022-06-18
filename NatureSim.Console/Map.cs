using System;

namespace NatureSim.Console
{
	class Map
    {
        public readonly int width = 10;
        public readonly int height = 10;
        private Random random = new Random();
        private Biome[] biomes = {
                new Forest(),
                new Swamp(),
                new Field(),
                new Mountain(),
                new Ocean(),
                new River()
        };
        public void GenerateMap()
        {
            Biome[,] map = new Biome[width, height];
            for (int currentWidth = 0; currentWidth < width; currentWidth++)
            {
                for (int currentHeight = 0; currentHeight < height; currentHeight++)
                {
                    map[currentWidth, currentHeight] = biomes[random.Next(biomes.Length)];
                }
            }
        }
    }
}
