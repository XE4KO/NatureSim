using System.Linq;

namespace NatureSim.Console
{
    class Bunny
    {
        private int _health = 3;
        private readonly string[] _diet = { "berry", "carrot" };
        public Bunny()
        {
        }
        private bool IsAlive => _health > 0;
        public void Eat(string foodName)
        {
            if (IsAlive)
            {
                if (_diet.Contains(foodName))
                {

                    _health++;
                    System.Console.WriteLine($"Bunny eats {foodName} and has {_health} health.");
                }
                else
                {
                    _health--;
                    System.Console.WriteLine($"Bunny does not eat {foodName} and is left with {_health} health");
                }
            }
            else
            {
                System.Console.WriteLine($"Bunny is dead and cannot eat {foodName}");
            }
        }
    }
}
