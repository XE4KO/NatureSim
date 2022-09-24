using System;

namespace NatureSim.Console
{
    static class Configuration
    {
        public static bool DetailedInfo = false;
        public static int Seed = 0;
        public static Random CreateRandom()
        {
            if (Seed >= 0)
                return new Random(Seed);
            return new Random();
        }
    }
}
