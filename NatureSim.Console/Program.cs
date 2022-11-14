using System;
using System.Collections.Generic;

namespace NatureSim.Console
{
	partial class Program
    {
        //!!!!!ask about how to make foods give different health using records!!!!!
        static void Main(string[] args)
        {
            Map map = new Map(5, 10);
            List<Animal> animals = new List<Animal>() {
                new Bunny(map),
                new Wolf(map),
                new Bear(map),
                new Cat(map),
                new Lion(map),
                new Bunny(map),
                new Wolf(map),
                new Bear(map),
                new Cat(map),
                new Lion(map)
            };

            List<Animal> aliveAnimals;
            do
            {
                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.Clear();
                aliveAnimals = new List<Animal>();
                foreach (var animal in animals)
                {
                    animal.Eat(map.FindFood(animal._coordsX, animal._coordsY));
                    animal.Move();
                    if (animal.IsAlive)
                    {
                        aliveAnimals.Add(animal);
                    }
                }
                map.Update();
                animals = aliveAnimals;
                
            } while (aliveAnimals.Count > 0 && !CanExit());
            System.Console.WriteLine($"Last animal survived {map.Ticks} ticks.");
        }

        private static bool CanExit()
        {
            if (Configuration.DetailedInfo)
                return System.Console.ReadKey().Key == ConsoleKey.Escape;
            return false;
        }
    }
}
