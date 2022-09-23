namespace NatureSim.Console
{
    class FoodData
    {
        public FoodData(FoodInfo food)
        {
            Info = food;
            Amount = food.MaxAmount;
        }

        public FoodData(FoodInfo food, int amount)
        {
            Info = food;
            Amount = amount;
        }


        public FoodInfo Info { get; }
        public int Amount { get; private set; }
        public int Nutrients => Amount * Info.nutrients;

        internal FoodData Consume(int consumeAmount)
        {
            if (Amount < consumeAmount)
                consumeAmount = Amount;
            Amount -= consumeAmount;
            return new FoodData(Info, consumeAmount);
        }

        private int updatedTick = 0;
        internal void Regen(int lastTick)
        {
            var regen = (lastTick - updatedTick) / Info.RegenRate;
            if (regen > 0)
            {
                if (Amount < Info.MaxAmount)
                    Amount += regen;
                updatedTick += lastTick - lastTick % Info.RegenRate;
            }
        }
    }
}
