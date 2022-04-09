using System.Collections.Generic;

namespace NatureSim.Console
{
    class Bunny : Animal
    {
        public Bunny()
            : base("Bunny", 3, new HashSet<string>() { "berry", "carrot", "grass", "cabage", "acorn", "almond" })
        {
        }
    }
}
