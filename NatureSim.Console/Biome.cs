using System;

namespace NatureSim.Console
{
    internal record Biome(int FoodScarcity, params FoodInfo[] AvailableFoods)
    {
    }

    record Field() : Biome(0, new Grass(20, 2), new Meat(5, 3), new Carrot(10, 3));
    record Forest() : Biome(5, new Berry(15, 3), new Meat(10, 2), new Grass(10, 3), new Carrot(5, 4), new Acorn(10, 2), new Mouse(5, 6));
    record Mountain() : Biome(10, new Grass(7, 4), new Berry(10, 4));
    record River() : Biome(15, new Fish(10, 2));
    record Swamp() : Biome(10, new Fish(5, 5), new Fly(12, 2));
    record Ocean() : Biome(10, new Fish(20, 3));
}
