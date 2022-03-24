
using System.Linq;

namespace NatureSim.Console
{
    class Wolf
    {
        private int _health = 10;
        private readonly string[] _diet = { "meat", "fish", "giraffe", "elephant" };
        public Wolf()
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
                    System.Console.WriteLine($"Wolf eats {foodName} and has {_health} health.");
                }
                else
                {
                    _health--;
                    if (!IsAlive)
                    {
                        System.Console.BackgroundColor = System.ConsoleColor.DarkRed;
                        System.Console.Write($"Wolf does not eat {foodName} and died");
                        System.Console.BackgroundColor = System.ConsoleColor.Black;
                        System.Console.WriteLine(" ");
                    }
                    else
                        System.Console.WriteLine($"Wolf does not eat {foodName} and is left with {_health} health.");
                }
            }
            //else
            //{
            //    System.Console.WriteLine($"Wolf is dead and cannot eat {foodName}");
            //}
        }
    }
}
