using System.Collections.Generic;

namespace NatureSim.Console
{
    class Wolf : Animal
    {
        public Wolf()
            : base("Wolf", 13, new HashSet<Food>() { Food.meat, Food.fish})
        {
        }
    }
}
