using System;
using System.Collections.Generic;

namespace NatureSim.Console
{
    partial class Program
    {
        static void Main(string[] args)
        {
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
                Food.berry, Food.carrot, Food.carrot, Food.grass, Food.grass, Food.grass, Food.acorn, Food.acorn,
                Food.fish, Food.fish, Food.meat, Food.meat, Food.mouse, Food.catFood, Food.catFood, Food.catFood,
                Food.nothing, Food.nothing, Food.nothing};

            var random = new Random();
            List<Animal> aliveAnimals;
            do
            {
                aliveAnimals = new List<Animal>();
                foreach (var animal in animals)
                {
                    animal.Eat(food[random.Next(food.Length)]);
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
