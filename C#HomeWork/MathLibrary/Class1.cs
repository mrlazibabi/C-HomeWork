namespace MathLibrary
{
    public static class MathOperations
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b) => a / b;

        public static double Power(double baseNum, double exponent) => Math.Pow(baseNum, exponent);
        public static double SquareRoot(double num) => Math.Sqrt(num);
    }
}
