using System.Collections.Generic;

namespace NatureSim.Console
{
    class Bear : Animal
    {
        public Bear()
            : base("Bear", 15, new HashSet<Food>() { Food.meat, Food.fish, Food.berry })
        {
        }
    }
}
