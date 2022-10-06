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
        public int Nutrients => Amount * Info.Nutrients;

        internal FoodData Consume(int consumeAmount)
        {
            if (Amount < consumeAmount)
                consumeAmount = Amount;
            Amount-= consumeAmount;
            return new FoodData(Info, consumeAmount);
        }

        internal void Regen()
        {
            if (Amount < Info.MaxAmount)
            {
                Amount++;
            }
        }
    }
}
