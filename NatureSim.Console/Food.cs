using System;

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

    abstract class FoodInfo
    {
        public int nutrients { get; }
        public Foods foodName { get; }
        public int MaxAmount { get; }
        public int RegenRate { get; }
        public FoodInfo(int nutrients, Foods foodName, int maxAmount, int regenRate)
        {
            this.nutrients = nutrients;
            this.foodName = foodName;
            MaxAmount = maxAmount;
            RegenRate = regenRate;
        }
        internal virtual string GetDoesNotEatMessage()
            => $"does not eat {foodName}";
    }
    class Berry : FoodInfo
    {
        public Berry(int maxAmount, int regenRate) 
            : base(1, Foods.berry, maxAmount, regenRate) { }
    }
    class Carrot : FoodInfo
    {
        public Carrot(int maxAmount, int regenRate)
            : base(3, Foods.carrot, maxAmount, regenRate) { }
    }
    class Grass : FoodInfo
    {
		public Grass(int maxAmount, int regenRate)
			: base(1, Foods.grass, maxAmount, regenRate) { }
	}
    class Acorn : FoodInfo
    {
        public Acorn(int maxAmount, int regenRate)
            : base(2, Foods.acorn, maxAmount, regenRate) { }
    }
    class Fish : FoodInfo
    {
        public Fish(int maxAmount, int regenRate)
            : base(4, Foods.fish, maxAmount, regenRate) { }
    }
    class Meat : FoodInfo
    {
        public Meat(int maxAmount, int regenRate)
            : base(5, Foods.meat, maxAmount, regenRate) { }
    }
    class Mouse : FoodInfo
    {
        public Mouse(int maxAmount, int regenRate)
            : base(2, Foods.mouse, maxAmount, regenRate) { }
    }
    class Fly : FoodInfo
    {
        public Fly(int maxAmount, int regenRate)
            : base(1, Foods.fly, maxAmount, regenRate) { }
    }
    class NoFood : FoodInfo
    {
        public static readonly NoFood Instance = new NoFood();
        private NoFood()
            : base(0, Foods.nothing, 0, 0) { }

        internal override string GetDoesNotEatMessage()
            => $"does not find any food";
    }
}
