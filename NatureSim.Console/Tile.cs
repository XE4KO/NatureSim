using System;
using System.Collections.Generic;
using System.Linq;

namespace NatureSim.Console
{
	class Tile
	{
		private readonly Biome biome;
		private readonly int[] foodAmount;
		public Tile(Biome biome)
		{
			this.biome = biome;
			var foodCount = biome.AvailableFoods.Length;
			this.foodAmount = biome.AvailableFoods.Select(x => x.MaxAmount).ToArray();
			//this.foodAmount = new int[foodCount];
			////TODO: Fill foodCount with Food.MaxAmount
			//for (int foodIndex = 0; foodIndex < foodCount; foodIndex++)
			//	foodAmount[foodIndex] = biome.AvailableFoods[foodIndex].MaxAmount;
		}
	}
}
