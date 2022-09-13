using System;
using System.Linq;
using System.Collections.Generic;

namespace NatureSim.Console
{
    class Animal
    {
        private readonly string animalType;
        private int health;
        private readonly HashSet<Foods> diet;
        private int starve;
        public int coordsX;
        public int coordsY;
        private Random random = new Random();
        Map map = new Map();
        public Animal(string animalType, int health, int starve, IEnumerable<Foods> diet)
        {
            this.animalType = animalType;
            this.health = health;
            this.starve = starve;
            this.diet = new HashSet<Foods>(diet);
            this.coordsX = random.Next(map.Width);
            this.coordsY = random.Next(map.Height);
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
                        System.Console.ReadKey();
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
            coordsX = map.LimitX(coordsX);
            coordsY = map.LimitY(coordsY);
			//System.Console.WriteLine($"{animalType} moved to [{coordsX}:{coordsY}].");
		}

	}
}
