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
        public int MaxAmount { get; }
        public Food(int nutrients, Foods foodName, int maxAmount)
        {
            this.nutrients = nutrients;
            this.foodName = foodName;
            MaxAmount = maxAmount;
        }
    }
    class Berry : Food
    {
        public Berry(int maxAmount) 
            : base(1, Foods.berry, maxAmount) { }
    }
    class Carrot : Food
    {
        public Carrot(int maxAmount)
            : base(3, Foods.carrot, maxAmount) { }
    }
    class Grass : Food
    {
		public Grass(int maxAmount)
			: base(1, Foods.grass, maxAmount) { }
	}
    class Acorn : Food
    {
        public Acorn(int maxAmount)
            : base(2, Foods.acorn, maxAmount) { }
    }
    class Fish : Food
    {
        public Fish(int maxAmount)
            : base(4, Foods.fish, maxAmount) { }
    }
    class Meat : Food
    {
        public Meat(int maxAmount)
            : base(5, Foods.meat, maxAmount) { }
    }
    class Mouse : Food
    {
        public Mouse(int maxAmount)
            : base(2, Foods.mouse, maxAmount) { }
    }
    class Fly : Food
    {
        public Fly(int maxAmount)
            : base(1, Foods.fly, maxAmount) { }
    }
    class Nothing : Food
    {
        public Nothing(int maxAmount)
            : base(0, Foods.nothing, maxAmount) { }
    }
}
