using System.Collections.Generic;

namespace NatureSim.Console
{
    class Bear : Animal
    {
        public Bear()
            : base("Bear", 15, new HashSet<string>() {"meat", "fish", "berry" })
        {
        }
    }
}
