using System;
using System.Collections.Generic;
using System.Linq;

namespace NatureSim.Console
{
    class Tile
    {
        static readonly Random _random = Configuration.CreateRandom();
        private readonly Biome _biome;
        private readonly FoodData[] _food;
        private readonly int _maxTotalFoodAmount;
        public Tile(Biome biome)
        {
            this._biome = biome;
            var foodCount = biome.AvailableFoods.Length;
            this._food = biome.AvailableFoods.Select(x => new FoodData(x)).ToArray();
            this._maxTotalFoodAmount = biome.AvailableFoods.Sum(x => x.MaxAmount) + biome.FoodScarcity;
        }

        internal FoodData FindFood()
        {
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
