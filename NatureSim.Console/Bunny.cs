using System.Collections.Generic;

namespace NatureSim.Console
{
    class Bunny : Animal
    {
        public Bunny()
            : base("Bunny", 3, new HashSet<Food>() { Food.berry, Food.carrot, Food.grass, Food.acorn, })
        {
        }
    }
}
