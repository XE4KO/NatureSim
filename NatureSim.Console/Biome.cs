using System;

namespace NatureSim.Console
{
	internal record Biome(Food[] AvailableFoods)
	{
		static readonly Random random = new();

		internal Food FindFood()
			=> AvailableFoods[random.Next(AvailableFoods.Length)];
	}

	record Field() : Biome(new Food[] {     new Grass(20),    new Meat(5),     new Carrot(10) });
    record Forest() : Biome(new Food[] {    new Berry(15),    new Meat(10),     new Grass(10),    new Carrot(5), new Acorn(10), new Mouse(5) });
    record Mountain() : Biome(new Food[] {    new Nothing(10),  new Grass(7),    new Berry(10) });
    record River() : Biome(new Food[] {     new Fish(10),  new Nothing(10) });
    record Swamp() : Biome(new Food[] {     new Fish(5),     new Nothing(10),  new Fly(12)});
    record Ocean() : Biome(new Food[] {     new Fish(20),     new Nothing(5) });

}
