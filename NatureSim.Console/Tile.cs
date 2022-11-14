using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NatureSim.Console
{
    class Tile
    {
        static readonly Random _random = Configuration.Random;
        private readonly FoodData[] _food;
        private readonly int _maxTotalFoodAmount;

        public Biome Biome { get; }

        public Tile(Biome biome)
        {
            _food = biome.AvailableFoods.Select(x => new FoodData(x)).ToArray();
            _maxTotalFoodAmount = biome.AvailableFoods.Sum(x => x.MaxAmount) + biome.FoodScarcity;
            Biome = biome;
        }

        internal FoodData FindFood()
        {
            Debug.WriteLine(string.Join(", ", _food.Select(x=> $"{x.Info.FoodName} {x.Amount}/{x.Info.MaxAmount}")));

            var totalFoodAmountIndex = _random.Next(_maxTotalFoodAmount);
            int foodIndex = SelectFoodIndex(totalFoodAmountIndex);
            if (foodIndex < _food.Length)
                return _food[foodIndex];
            return new FoodData(NoFood.Instance);
        }

        private int SelectFoodIndex(int totalFoodAmountIndex)
        {
            var currentTotalFoodAmount = 0;
            int currentFoodIndex;
            for (currentFoodIndex = 0; currentFoodIndex < _food.Length; currentFoodIndex++)
            {
                currentTotalFoodAmount += _food[currentFoodIndex].Amount;
                if (totalFoodAmountIndex < currentTotalFoodAmount)
                    break;
            }

            return currentFoodIndex;
        }

        public void OnUpdate(int ticks)
        {
            foreach(var food in this._food)
            {
                if (ticks % food.Info.RegenRate == 0)
                {
                    food.Regen();
                }
            }
        }
    }
}
