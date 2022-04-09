using System.Collections.Generic;

namespace NatureSim.Console
{
    class Lion : Animal
    {
        public Lion()
            : base("Lion", 13, new HashSet<Food>() { Food.mouse, Food.meat, Food.fish })
        {
        }
    }
}
