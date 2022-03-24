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
            string[] food = {
                "berry", "carrot", "grass", "cabage", "acorn", "almond",
                "fish", "meat", "meat", "giraffe", "elephant",
                "nothing", "nothing", "nothing"};
            var random = new Random();
            do
            {
                bunny.Eat(food[random.Next(food.Length)]);
                wolf.Eat(food[random.Next(food.Length)]);
                bear.Eat(food[random.Next(food.Length)]);
            } while (bear.IsAlive || wolf.IsAlive || bunny.IsAlive);
        }
    }
}
