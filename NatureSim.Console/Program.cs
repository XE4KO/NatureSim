using System;
using System.Collections.Generic;

namespace NatureSim.Console
{
	partial class Program
    {
        //!!!!!ask about how to make foods give different health using records!!!!!
        static void Main(string[] args)
        {
            Map map = new Map();
            map.GenerateMap(5,10);
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

            List<Animal> aliveAnimals;
            do
            {
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.Clear();
                aliveAnimals = new List<Animal>();
                foreach (var animal in animals)
                {
                    var animalCurrentTile = map[animal._coordsX, animal._coordsY];
                    animal.Eat(animalCurrentTile.FindFood());
                    animal.Move();
                    if (animal.IsAlive)
                    {
                        aliveAnimals.Add(animal);
                    }
                }
                map.Update();
                animals = aliveAnimals;
                if (Configuration.DetailedInfo)
                    System.Console.ReadKey();

            } while (aliveAnimals.Count > 0);
            System.Console.WriteLine($"Last animal survived {map.Ticks} ticks.");
        }
    }
}
