namespace NatureSim.Console
{
    class LinearInterpolation
    {
        private decimal _a;
        private decimal _b;

        public LinearInterpolation(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            _a = CalculateA(x1, y1, x2, y2);
            _b = CalculateB(x1, y1, x2, y2);
        }

        public decimal CalculateY(decimal x)
            => _a * x + _b;

        public decimal CalculateX(decimal y)
            => (y - _b) / _a;

        private static decimal CalculateA(decimal x1, decimal y1, decimal x2, decimal y2)
            => (y1 - y2) / (x1 - x2);
        private static decimal CalculateB(decimal x1, decimal y1, decimal x2, decimal y2)
            => (x1 * y2 - y1 * x2) / (x1 - x2);

    }
}
