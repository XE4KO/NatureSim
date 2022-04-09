using System.Collections.Generic;

namespace NatureSim.Console
{
    class Wolf : Animal
    {
        public Wolf()
            : base("Wolf", 10, new HashSet<string>() { "meat", "fish", "giraffe", "elephant"})
        {
        }
    }
}
