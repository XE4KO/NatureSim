using System;
using System.Linq;

namespace NatureSim.Console
{
    class Tile
    {
        static readonly Random random = new();
        private readonly Biome biome;
        private readonly int[] foodAmount;
        private readonly int maxTotalFoodAmount;
        public Tile(Biome biome)
        {
            this.biome = biome;
            var foodCount = biome.AvailableFoods.Length;
            this.foodAmount = biome.AvailableFoods.Select(x => x.MaxAmount).ToArray();
            this.maxTotalFoodAmount = biome.AvailableFoods.Sum(x => x.MaxAmount) + biome.FoodScarcity;
        }

        internal Food FindFood()
        {
            var totalFoodAmountIndex = random.Next(maxTotalFoodAmount);
            int foodIndex = SelectFoodIndex(totalFoodAmountIndex);
            if (foodIndex < foodAmount.Length)
            {
                foodAmount[foodIndex]--;
                return biome.AvailableFoods[foodIndex];
            }
            return NoFood.Instance;
        }

        private int SelectFoodIndex(int totalFoodAmountIndex)
        {
            var currentTotalFoodAmount = 0;
            int currentFoodIndex;
            for (currentFoodIndex = 0; currentFoodIndex < foodAmount.Length; currentFoodIndex++)
            {
                currentTotalFoodAmount += foodAmount[currentFoodIndex];
                if (totalFoodAmountIndex < currentTotalFoodAmount)
                    break;
            }

            return currentFoodIndex;
        }
    }
}
