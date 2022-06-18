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
        private int starve;
        private int coordsX;
        private int coordsY;
        private Random random = new Random();
        Map map = new Map();

        public Animal(string animalType, int health, int starve, IEnumerable<Foods> diet)
        {
            this.animalType = animalType;
            this.health = health;
            this.starve = starve;
            this.diet = new HashSet<Foods>(diet);
            this.coordsX = random.Next(map.width);
            this.coordsY = random.Next(map.height);
        }

        public bool IsAlive => health > 0;
        public void Eat(Food food)
        {
            if (IsAlive)
            {
                if (diet.Contains(food.foodName))
                {

                    health += food.nutrients;
                    System.Console.WriteLine($"{animalType} eats {food.foodName} and has {health} health.");
                }
                else
                {
                    health -= starve;
                    if (!IsAlive)
                    {
                        System.Console.BackgroundColor = System.ConsoleColor.DarkRed;
                        System.Console.Write($"{animalType} does not eat {food.foodName} and died");
                        System.Console.BackgroundColor = System.ConsoleColor.Black;
                        System.Console.WriteLine(" ");
                    }
                    else
                        System.Console.WriteLine($"{animalType} does not eat {food.foodName} and is left with {health} health.");
                }
            }
        }
        public void Move()
		{
            coordsX += random.Next(3) - 1;
            coordsY += random.Next(3) - 1;
			if (coordsX > map.width)
			{
                coordsX = 0;
			}
            if (coordsX < 0)
            {
                coordsX = map.width;
            }
            if (coordsY > map.height)
            {
                coordsY = 0;
            }
            if (coordsY < 0)
            {
                coordsY = map.height;
            }
            //System.Console.WriteLine($"{animalType} moved to [{coordsX}:{coordsY}].");
        }
    }
}
