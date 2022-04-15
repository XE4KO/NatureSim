using System;
using System.Linq;
using System.Collections.Generic;

namespace NatureSim.Console
{
    class Animal
    {
        private readonly string animalType;
        private int health;
        //private readonly string[] edibleFood;
        private readonly HashSet<Foods> diet;


        public Animal(string animalType, int health, HashSet<Foods> diet)
        {
            this.animalType = animalType;
            this.health = health;
            this.diet = diet;
        }

        public bool IsAlive => health > 0;
        public void Eat(Foods foodName, int healthGain)
        {
            if (IsAlive)
            {
                if (diet.Contains(foodName))
                {

                    health += healthGain;
                    System.Console.WriteLine($"{animalType} eats {foodName} and has {health} health.");
                }
                else
                {
                    health--;
                    if (!IsAlive)
                    {
                        System.Console.BackgroundColor = System.ConsoleColor.DarkRed;
                        System.Console.Write($"{animalType} does not eat {foodName} and died");
                        System.Console.BackgroundColor = System.ConsoleColor.Black;
                        System.Console.WriteLine(" ");
                    }
                    else
                        System.Console.WriteLine($"{animalType} does not eat {foodName} and is left with {health} health.");
                }
            }
            //else
            //{
            //    System.Console.WriteLine($"Wolf is dead and cannot eat {foodName}");
            //}
        }
    }
}
