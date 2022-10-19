using System;
using System.Linq;
using System.Collections.Generic;

namespace NatureSim.Console
{
    class Animal
    {
        private readonly string _animalType;
        private int _hunger;
        private int _hungerLoss;
        private int _health;
        private readonly HashSet<Foods> _diet;
        private int _starvingDamage;
        public int _coordsX;
        public int _coordsY;
        private Random _random = Configuration.CreateRandom();
        Map map = new Map();
        public Animal(string animalType, int hungerLoss, int health, int starvingDamage, IEnumerable<Foods> diet)
        {
            this._animalType = animalType;
            this._hunger = 0;
            this._hungerLoss = hungerLoss;
            this._health = health;
            this._starvingDamage = starvingDamage;
            this._diet = new HashSet<Foods>(diet);
            this._coordsX = _random.Next(map.Width);
            this._coordsY = _random.Next(map.Height);
        }

        public bool IsAlive => _health > 0;
        public void Eat(FoodData food)
        {
            if (IsAlive)
            {
                if (_diet.Contains(food.Info.FoodName))
                {
                    var consumedFood = food.Consume(1);
                    _hunger += consumedFood.Nutrients;
                    LimitHunger();
                    System.Console.BackgroundColor = ConsoleColor.DarkGreen;
                    System.Console.Write($"{_animalType} eats {food.Info.FoodName} and has {_health} health.");
                    System.Console.BackgroundColor = ConsoleColor.Black;
                    System.Console.WriteLine(' ');
                }
                else
                {
                    _hunger -= _hungerLoss;
                    LimitHunger();
                    //_health -= _starvingDamage;
                    string doesNotEatMessage = food.Info.GetDoesNotEatMessage();
                    if (!IsAlive)
                    {
                        System.Console.BackgroundColor = ConsoleColor.DarkRed;
                        System.Console.Write($"{_animalType} {doesNotEatMessage} and died");
                        System.Console.BackgroundColor = ConsoleColor.Black;
                        System.Console.WriteLine(' ');
                        if (Configuration.DetailedInfo)
                            System.Console.ReadKey();
                    }
                    else if (Configuration.DetailedInfo)
                        System.Console.WriteLine($"{_animalType} {doesNotEatMessage} and is left with {_hunger} hunger.");
                }
            }
        }

        public void Move()
		{
			_coordsX += _random.Next(3) - 1;
			_coordsY += _random.Next(3) - 1;
            _coordsX = map.LimitX(_coordsX);
            _coordsY = map.LimitY(_coordsY);
			//System.Console.WriteLine($"{animalType} moved to [{coordsX}:{coordsY}].");
		}

        private void LimitHunger()
        {
            if (_hunger > 100)
            {
                _hunger = 100;
            }
            if (_hunger < 0)
            {
                _hunger = 0;
            }
        }

	}
}
