using System;

namespace NatureSim.Console
{
    internal record Biome(int FoodScarcity, params Food[] AvailableFoods)
    {
        static readonly Random random = new();

        internal Food FindFood()
            => AvailableFoods[random.Next(AvailableFoods.Length)];
    }

    record Field() : Biome(0, new Grass(20), new Meat(5), new Carrot(10));
    record Forest() : Biome(5, new Berry(15), new Meat(10), new Grass(10), new Carrot(5), new Acorn(10), new Mouse(5));
    record Mountain() : Biome(10, new Grass(7), new Berry(10));
    record River() : Biome(15, new Fish(10));
    record Swamp() : Biome(10, new Fish(5), new Fly(12));
    record Ocean() : Biome(10, new Fish(20));

}
