using System;
using System.Collections.Generic;

namespace NatureSim.Console
{
    
    partial class Program
    {
        //!!!!!ask about how to make foods give different health using records!!!!!
        static void Main(string[] args)
        {
            var mapWidth = 10;
            var mapHeight = 10;
            var random = new Random();
            
            List<Animal> animals = new List<Animal>() {
                new Bunny(),
                new Wolf(),
                new Bear(),
                new Cat(),
                new Lion(),
                new Bunny(),
                new Wolf(),
                new Bear(),
                new Cat(),
                new Lion()
            };

            Food[] food = {
                new Berry(), new Carrot(), new Carrot(), new Grass(), new Grass(), new Grass(), new Acorn(), new Acorn(),
                new Fish(), new Fish(), new Meat(), new Meat(), new Mouse(), new Fly(), new Fly(), new Fly(),
                new Nothing(), new Nothing(), new Nothing()};

            Biome[] biomes = {
                new Forest(),
                new Swamp(),
                new Field(),
                new Mountain(),
                new Ocean(),
                new River()
            };
            Biome[,] map = new Biome[mapWidth, mapHeight];
			/*foreach (var tile in map)
            {
                var biome = biomes[random.Next(biomes.Length)];
                tile = biome;
            }*/
			for (int currentMapWidth = 0; currentMapWidth < mapWidth; currentMapWidth++)
			{
				for (int currentMapHeight = 0; currentMapHeight < mapHeight; currentMapHeight++)
				{
                    map[currentMapWidth, currentMapHeight] = biomes[random.Next(biomes.Length)];
                }
			}

            List<Animal> aliveAnimals;
            do
            {
                aliveAnimals = new List<Animal>();
                foreach (var animal in animals)
                {
                    var eating = food[random.Next(food.Length)];
                    animal.Eat(eating);
                    if (animal.IsAlive)
                    {
                        aliveAnimals.Add(animal);
                    }
                }
                animals = aliveAnimals;
            } while (aliveAnimals.Count > 0);
        }
    }
}
