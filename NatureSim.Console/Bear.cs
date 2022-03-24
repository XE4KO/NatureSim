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
        public bool IsAlive => _health > 0;
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
                    if (!IsAlive)
                    {
                        System.Console.BackgroundColor = System.ConsoleColor.DarkRed;
                        System.Console.Write($"Bear does not eat {foodName} and died");
                        System.Console.BackgroundColor = System.ConsoleColor.Black;
                        System.Console.WriteLine(" ");
                    } else
                        System.Console.WriteLine($"Bear does not eat {foodName} and is left with {_health} health");
                }
            }
            //else
            //{
            //    System.Console.WriteLine($"Bear is dead and cannot eat {foodName}");
            //}
        }
    }
}
