using System.Linq;

namespace NatureSim.Console
{
    class Bear
    {
        private int _health = 15;
        private readonly string[] _diet = { "meat", "fish", "berry" };
        public Bear()
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
                    System.Console.WriteLine($"Bear eats {foodName} and has {_health} health.");
                }
                else
                {
                    _health--;
                    System.Console.WriteLine($"Bear does not eat {foodName} and is left with {_health} health");
                }
            }
            else
            {
                System.Console.WriteLine($"Bear is dead and cannot eat {foodName}");
            }
        }
    }
}
