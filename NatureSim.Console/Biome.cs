using System;

namespace NatureSim.Console
{
	internal record Biome(Food[] AvailableFoods)
	{
		static readonly Random random = new();

		internal Food FindFood()
			=> AvailableFoods[random.Next(AvailableFoods.Length)];
	}

	record Field() : Biome(new Food[] {     new Grass(50),    new Meat(),     new Carrot(20) });
    record Forest() : Biome(new Food[] {    new Berry(),    new Meat(),     new Grass(),    new Carrot(), new Acorn(), new Mouse() });
    record Mountain() : Biome(new Food[] {  new Nothing(),  new Nothing(),  new Grass(),    new Berry() });
    record River() : Biome(new Food[] {     new Fish(),     new Fish(),     new Nothing(),  new Nothing() });
    record Swamp() : Biome(new Food[] {     new Fish(),     new Nothing(),  new Fly(),      new Fly()});
    record Ocean() : Biome(new Food[] {     new Fish(),     new Nothing(),  new Nothing(),  new Nothing() });

}
