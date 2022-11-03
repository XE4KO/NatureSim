using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace NatureSim.Console
{
    class Animal
    {
        private readonly string _animalType;
        private int _hunger;
        private int _maxHunger;
        private int _hungerLoss;
        private int _health;
        private int _maxHealth;
        private int _starvingDamage;
        private int _healthRegen;
        private readonly HashSet<Foods> _diet;
        public int _coordsX;
        public int _coordsY;
        private Random _random = Configuration.CreateRandom();
        Map map = new Map();
        public Animal(string animalType, int maxHunger, int hungerLoss, int health, int maxHealth, int starvingDamage, int healthRegen, IEnumerable<Foods> diet)
        {
            this._animalType = animalType;
            this._hunger = maxHunger;
            this._maxHunger = maxHunger;
            this._hungerLoss = hungerLoss;
            this._health = health;
            this._maxHealth = maxHealth;
            this._starvingDamage = starvingDamage;
            this._healthRegen = healthRegen;
            this._diet = new HashSet<Foods>(diet);
            this._coordsX = _random.Next(map.Width);
            this._coordsY = _random.Next(map.Height);
        }

        public bool IsAlive => _health > 0;
        public void Eat(FoodData food)
        {
            if (IsAlive)
            {
                SetHunger(_hunger - _hungerLoss);
                var consumableFood = _diet.Contains(food.Info.FoodName);
                Color? hungerColor = null;
                string eatMessage;
                if (consumableFood)
                {
                    var consumedFood = food.Consume(1);
                    SetHunger(_hunger + consumedFood.Nutrients);
                    hungerColor = Color.DarkGreen;
                    eatMessage = $"eats {food.Info.FoodName}";
                }
                else
                {
                    hungerColor = Color.DarkRed;
                    eatMessage = food.Info.GetDoesNotEatMessage();
                }
                Color? hungerMessageColor = null;
                string hungerMessage = "";
                if (_hunger <= _maxHunger / 3)
                {
                    SetHealth(_health - _starvingDamage);

                    if (!IsAlive)
                    {
                        hungerMessageColor = Color.DarkRed;
                        hungerMessage = $"Now it has starved to death.";
                        //if (Configuration.DetailedInfo)
                        //    System.Console.ReadKey();
                    }
                    else
                    {
                        hungerMessageColor = Color.YellowGreen;
                        hungerMessage = $"Now it's starving";
                    }
                }
                else if (_hunger >= (_maxHunger / 3) * 2)
                {
                    SetHealth(_health + _healthRegen);
                    if(_health < _maxHealth)
                        hungerMessageColor = Color.DarkGreen;
                    hungerMessage = $"Now it's well fed";
                }
                //PrintResult($"{_animalType} eats {food.Info.FoodName} and has {_hunger} hunger." );
                var hungerString = ConsoleEx.Format($"{_hunger,3}", hungerColor ?? Color.Black, Color.White);
                var healthString = ConsoleEx.Format($"{_health,3}", hungerMessageColor ?? Color.Black, Color.White);
                //PrintResult($"{_animalType,10}, HG({hungerString}), HP({_health,3}) {eatMessage}. Now {hungerMessage}\r\n", color);
                System.Console.WriteLine($"{_animalType,10}, HG({hungerString}), HP({healthString}) {eatMessage}. {hungerMessage}");
            }
        }

        private void PrintResult(string value, ConsoleColor? color = null)
        {
            if (color.HasValue)
                System.Console.BackgroundColor = color.Value;
            System.Console.Write(value);
            if (color.HasValue)
                System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.WriteLine(' ');
        }

        public void Move()
        {
            _coordsX += _random.Next(3) - 1;
            _coordsY += _random.Next(3) - 1;
            _coordsX = map.LimitX(_coordsX);
            _coordsY = map.LimitY(_coordsY);
            //System.Console.WriteLine($"{animalType} moved to [{coordsX}:{coordsY}].");
        }

        private void SetHunger(int hunger)
        {
            if (hunger > _maxHunger)
            {
                _hunger = _maxHunger;
            }
            else if (hunger < 0)
            {
                _hunger = 0;
            }
            else
            {
                _hunger = hunger;
            }
        }

        private void SetHealth(int health)
        {
            if (health > _maxHealth)
            {
                _health = _maxHealth;
            }
            else if (health < 0)
            {
                _health = 0;
            }
            else
            {
                _health = health;
            }
        }
    }
}
