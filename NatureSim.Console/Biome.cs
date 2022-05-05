using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureSim.Console
{
    record Biome(Food[] availableFoods);
    record Field() : Biome(new Food[] { new Grass(), new Meat(), new Carrot() });
    record Forest() : Biome(new Food[] { new Berry(), new Meat(), new Grass(), new Carrot(), new Acorn(), new Mouse() });
    record Mountain() : Biome(new Food[] { new Nothing(), new Nothing(), new Grass(), new Berry() });
    record River() : Biome(new Food[] { new Fish(), new Fish(), new Nothing(), new Nothing() });
    record Swamp() : Biome(new Food[] { new Fish(), new Nothing(), new Fly(), new Fly()});
    record Ocean() : Biome(new Food[] { new Fish(), new Nothing(), new Nothing(), new Nothing() });

}
