namespace TestNumberUtils
{
    public class NumberUtils
    {
        public bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public int SumPrimeNumbers(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers), "Array cannot be null");
            }

            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                if (IsPrime(number))
                {
                    sum += number;
                }
            }
            return sum;
        }
    }

}
