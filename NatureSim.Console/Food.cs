namespace NatureSim.Console
{
    enum Foods
    {
        berry,
        carrot,
        grass,
        acorn,
        fish,
        meat,
        mouse,
        fly,
        nothing
    }

    class Food
    {
        public int nutrients { get; }
        public Foods foodName { get; }
        public Food(int nutrients, Foods foodName)
        {
            this.nutrients = nutrients;
            this.foodName = foodName;
        }
    }
    class Berry : Food
    {
        public Berry()
            : base(1, Foods.berry)
        {

        }
    }
    class Carrot : Food
    {
        public Carrot()
            : base(3, Foods.carrot)
        {

        }
    }
    class Grass : Food
    {
        public Grass()
            : base(1, Foods.grass)
        {

        }
    }
    class Acorn : Food
    {
        public Acorn()
            : base(2, Foods.acorn)
        {

        }
    }
    class Fish : Food
    {
        public Fish()
            : base(4, Foods.fish)
        {

        }
    }
    class Meat : Food
    {
        public Meat()
            : base(5, Foods.meat)
        {

        }
    }
    class Mouse : Food
    {
        public Mouse()
            : base(2, Foods.mouse)
        {

        }
    }
    class Fly : Food
    {
        public Fly()
            : base(1, Foods.fly)
        {

        }
    }
    class Nothing : Food
    {
        public Nothing()
            : base(0, Foods.nothing)
        {

        }
    }
}
