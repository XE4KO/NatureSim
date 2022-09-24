using System;
using System.Collections.Generic;
using System.Linq;

namespace NatureSim.Console
{
    class Tile
    {
        static readonly Random random = Configuration.CreateRandom();
        private readonly Biome biome;
        private readonly FoodData[] food;
        private readonly int maxTotalFoodAmount;
        public Tile(Biome biome)
        {
            this.biome = biome;
            var foodCount = biome.AvailableFoods.Length;
            this.food = biome.AvailableFoods.Select(x => new FoodData(x)).ToArray();
            this.maxTotalFoodAmount = biome.AvailableFoods.Sum(x => x.MaxAmount) + biome.FoodScarcity;
        }

        internal FoodData FindFood()
        {
            var totalFoodAmountIndex = random.Next(maxTotalFoodAmount);
            int foodIndex = SelectFoodIndex(totalFoodAmountIndex);
            if (foodIndex < food.Length)
                return food[foodIndex];
            return new FoodData(NoFood.Instance);
        }

        private int SelectFoodIndex(int totalFoodAmountIndex)
        {
            var currentTotalFoodAmount = 0;
            int currentFoodIndex;
            for (currentFoodIndex = 0; currentFoodIndex < food.Length; currentFoodIndex++)
            {
                currentTotalFoodAmount += food[currentFoodIndex].Amount;
                if (totalFoodAmountIndex < currentTotalFoodAmount)
                    break;
            }

            return currentFoodIndex;
        }

        private int updatedTick = 0;
        public void OnUpdate(int lastTick)
        {
            if (NeedUpdated(lastTick))
            {
                foreach (var food in this.food)
                {
                    food.Regen(lastTick);
                    //if (lastTicks % food.Info.RegenRate == 0)
                    //{
                    //    food.Regen();
                    //}
                }
            }
        }
        private bool NeedUpdated(int lastTick)
        {
            var result = updatedTick != lastTick;
            if (result)
                updatedTick = lastTick;
            return result;
        }
    }
}
