using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace NatureSim.Console
{
    abstract class Animal
    {
        private readonly string _animalType;
        private int _hunger;
        private const int _maxHunger = 100;
        private const int _highHunger = 60;
        private const int _highHungerConsumeFood = 5;
        private const int _lowHunger = 30;
        private const int _lowHungerConsumeFood = 10;
        private int _hungerLoss;
        private int _health;
        private int _maxHealth;
        private int _starvingDamage;
        private int _healthRegen;
        private readonly HashSet<Foods> _diet;
        public int _coordsX;
        public int _coordsY;
        private readonly Random _random = Configuration.Random;
        private readonly Map _map;
        private readonly LinearInterpolation _hungerConsumeFoodInterpolation;
        public Animal(Map map, string animalType, int hungerLoss, int health, int maxHealth, int starvingDamage, int healthRegen, IEnumerable<Foods> diet)
        {
            _map = map;
            _animalType = animalType;
            _hunger = _maxHunger;
            _hungerLoss = hungerLoss;
            _health = health;
            _maxHealth = maxHealth;
            _starvingDamage = starvingDamage;
            _healthRegen = healthRegen;
            _diet = new HashSet<Foods>(diet);
            _coordsX = _random.Next(_map.Width);
            _coordsY = _random.Next(_map.Height);
            _hungerConsumeFoodInterpolation = new LinearInterpolation(_lowHunger, _lowHungerConsumeFood, _highHunger, _highHungerConsumeFood);
        }

        public bool IsAlive => _health > 0;

        private int GetFoodConsumeQuantity(int hunger)
            => Convert.ToInt32(_hungerConsumeFoodInterpolation.CalculateY(hunger));//addd linear interpolation equation
        public void Eat(FoodData food)
        {
            if (IsAlive)
            {
                SetHunger(_hunger - _hungerLoss);
                var consumableFood = _diet.Contains(food.Info.FoodName);
                Color? hungerColor = Color.DarkRed;
                string eatMessage;
                if (consumableFood)
                {
                    int consumedAmmount = GetFoodConsumeQuantity(_hunger);
                    if (consumedAmmount > 0)
                    {
                        var consumedFood = food.Consume(consumedAmmount);
                        SetHunger(_hunger + consumedFood.Nutrients);
                        hungerColor = Color.DarkGreen;
                        eatMessage = $"eats {consumedAmmount} {food.Info.FoodName}";
                    }
                    else
                        eatMessage = $"found {food.Info.FoodName}, but lost interest";
                }
                else
                    eatMessage = food.Info.GetDoesNotEatMessage();

                Color? hungerMessageColor = null;
                string hungerMessage = "";
                if (_hunger <= _lowHunger)
                {
                    SetHealth(_health - _starvingDamage);

                    if (!IsAlive)
                    {
                        hungerMessageColor = Color.DarkRed;
                        hungerMessage = $"It has starved to death.";
                        //if (Configuration.DetailedInfo)
                        //    System.Console.ReadKey();
                    }
                    else
                    {
                        hungerMessageColor = Color.YellowGreen;
                        hungerMessage = $"Now it's starving";
                    }
                }
                else if (_hunger >= _highHunger)
                {
                    SetHealth(_health + _healthRegen);
                    if (_health < _maxHealth)
                        hungerMessageColor = Color.DarkGreen;
                    hungerMessage = $"Now it's well fed";
                }
                //PrintResult($"{_animalType} eats {food.Info.FoodName} and has {_hunger} hunger." );
                var hungerString = ConsoleEx.Format($"{_hunger,3}/{_maxHunger,3}", hungerColor ?? Color.Black, Color.White);
                var healthString = ConsoleEx.Format($"{_health,3}/{_maxHealth,3}", hungerMessageColor ?? Color.Black, Color.White);
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
            _coordsX = _map.LimitX(_coordsX + _random.Next(3) - 1);
            _coordsY = _map.LimitY(_coordsY + _random.Next(3) - 1);
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
