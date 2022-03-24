using System;
using System.Linq;

namespace NatureSim.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Bunny bunny = new Bunny();
            Wolf wolf = new Wolf();
            Bear bear = new Bear();
            string[] food = { "berry", "carrot", "fish", "meat", "nothing" };
            bunny.Eat(food[4]);
            wolf.Eat(food[3]);
            bear.Eat(food[1]);
            bunny.Eat(food[4]);
            bunny.Eat(food[4]);
            bunny.Eat(food[4]);
        }
    }
}
