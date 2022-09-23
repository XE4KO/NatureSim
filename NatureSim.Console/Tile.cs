using System;
using System.Collections.Generic;
using System.Linq;

namespace NatureSim.Console
{
    class FoodData
    {
        public FoodData(FoodInfo food)
        {
            Info = food;
            Amount = food.MaxAmount;
        }

        public FoodData(FoodInfo food, int amount)
        {
            Info = food;
            Amount = amount;
        }


        public FoodInfo Info { get; }
        public int Amount { get; private set; }
        public int Nutrients => Amount * Info.nutrients;

        internal FoodData Consume(int consumeAmount)
        {
            if (Amount < consumeAmount)
                consumeAmount = Amount;
            Amount-= consumeAmount;
            return new FoodData(Info, consumeAmount);
        }

        internal void Regen()
        {
            if (Amount < Info.MaxAmount)
            {
                Amount++;
            }
        }
    }
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

        public void OnUpdate(int ticks)
        {
            foreach(var food in this.food)
            {
                if (ticks % food.Info.RegenRate == 0)
                {
                    food.Regen();
                }
            }
        }
    }
}
