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
                new Bear()
            };
            List<Animal> currentAnimals = new List<Animal>() {
                new Bunny(),
                new Wolf(),
                new Bear()
            };
            string[] food = {
                "berry", "carrot", "grass", "cabage", "acorn", "almond",
                "fish", "meat", "meat", "giraffe", "elephant",
                "nothing", "nothing", "nothing"};
            var random = new Random();
            do
            {
                foreach (var animal in animals)
                {
                    animal.Eat(food[random.Next(food.Length)]);
                    if (animal.IsAlive == false)
                    {
                        currentAnimals.Remove(animal);
                    }
                }
            } while (currentAnimals.Count > 0);
        }
    }
}
