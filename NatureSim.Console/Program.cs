using System;
using System.Collections.Generic;

namespace NatureSim.Console
{

    class Program
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
            string[] food = {
                "berry", "carrot", "grass", "cabage", "acorn", "almond",
                "fish", "meat", "meat", "giraffe", "elephant", "mouse", "cat food", "cat food", "cat food",
                "nothing", "nothing", "nothing"};

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
