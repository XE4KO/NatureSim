using System;

namespace NatureSim.Console
{
    static class Configuration
    {
        public static bool DetailedInfo = true;
        public static int Seed = 3;
        public static Random Random = CreateRandom();
        private static Random CreateRandom()
        {
            if (Seed >= 0)
                return new Random(Seed);
            return new Random();
        }
    }
}
