using System.Collections.Generic;

namespace NatureSim.Console
{
    class Bunny : Animal
    {
        public Bunny()
            : base("Bunny", 3, new HashSet<Foods>() { 
                Foods.berry, 
                Foods.carrot, 
                Foods.grass, 
                Foods.acorn, 
            })
        {
        }
    }
}
