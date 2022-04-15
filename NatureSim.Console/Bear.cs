using System.Collections.Generic;

namespace NatureSim.Console
{
    class Bear : Animal
    {
        public Bear()
            : base("Bear", 15, new HashSet<Foods>() { Foods.meat, Foods.fish, Foods.berry })
        {
        }
    }
}
