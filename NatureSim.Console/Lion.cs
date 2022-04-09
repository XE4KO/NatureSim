using System.Collections.Generic;

namespace NatureSim.Console
{
    class Lion : Animal
    {
        public Lion()
            : base("Lion", 10, new HashSet<string>() {"giraffe", "meat", "fish" })
        {
        }
    }
}
