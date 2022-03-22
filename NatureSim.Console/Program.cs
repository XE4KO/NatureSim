
namespace NatureSim.Console
{
    class Wolf
    {
        public Wolf()
        {
            int wolfHealth = 10;
            string[] wolfDiet = {"meat", "fish"};
        }
    }
    class Bear
    {
        public Bear()
        {
            int bearHealth = 15;
            string[] bearDiet = {"meat", "fish", "berry"};
        }
    }
    class Bunny
    {
        public Bunny()
        {
            int bunnyHealth = 5;
            string[] bunnyDiet = {"berry", "carrot"};
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bunny bunny = new Bunny();
            Wolf wolf = new Wolf();
            Bear bear = new Bear();
            string[] food = {"berry", "carrot", "fish", "meat", "nothing"};
            System.Console.WriteLine("Hello to Nature Simulator!");
        }
    }
}
