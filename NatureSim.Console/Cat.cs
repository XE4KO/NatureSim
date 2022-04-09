using System.Collections.Generic;

namespace NatureSim.Console
{
    class Cat : Animal
    {
        public Cat()
            : base ("Cat", 5, new HashSet<Food>(){ Food.mouse, Food.catFood, Food.fish})
        {
        }
    }
}
