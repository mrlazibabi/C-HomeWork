using TestNumberUtils;

namespace UnitTestNumberUtils
{
    public class UnitTest1
    {
        [Fact]
        public void IsPrime_InputIsPrime_ReturnsTrue()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();
            int number = 5;

            // Act
            bool result = numberUtils.IsPrime(number);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPrime_InputIsNotPrime_ReturnsFalse()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();
            int number = 4;

            // Act
            bool result = numberUtils.IsPrime(number);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPrime_InputIsLargePrime_ReturnsTrue()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();
            int number = 17; 

            // Act
            bool result = numberUtils.IsPrime(number);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPrime_InputIsLargeNonPrime_ReturnsFalse()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();
            int number = 9; 

            // Act
            bool result = numberUtils.IsPrime(number);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPrime_InputIsNegative_ReturnsFalse()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();
            int number = -7;

            // Act
            bool result = numberUtils.IsPrime(number);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPrime_InputIsZero_ReturnsFalse()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();
            int number = 0;

            // Act
            bool result = numberUtils.IsPrime(number);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPrime_InputIsTwo_ReturnsTrue()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();
            int number = 2;

            // Act
            bool result = numberUtils.IsPrime(number);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SumPrimeNumbers_ValidPrimeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();
            int[] numbers = { 2, 3, 5, 7 };

            // Act
            int sum = numberUtils.SumPrimeNumbers(numbers);

            // Assert
            Assert.Equal(17, sum);
        }

        [Fact]
        public void SumPrimeNumbers_NoPrimeNumbers_ReturnsZero()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();
            int[] numbers = { 4, 6, 8, 10 };

            // Act
            int sum = numberUtils.SumPrimeNumbers(numbers);

            // Assert
            Assert.Equal(0, sum);
        }

        [Fact]
        public void SumPrimeNumbers_InputContainsNegativeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();
            int[] numbers = { -1, -2, 3, 5, -7 };

            // Act
            int sum = numberUtils.SumPrimeNumbers(numbers);

            // Assert
            Assert.Equal(8, sum); // 3 + 5
        }

        [Fact]
        public void SumPrimeNumbers_InputIsEmptyArray_ReturnsZero()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();
            int[] numbers = { };

            // Act
            int sum = numberUtils.SumPrimeNumbers(numbers);

            // Assert
            Assert.Equal(0, sum);
        }

        [Fact]
        public void SumPrimeNumbers_NullArray_ThrowsArgumentNullException()
        {
            // Arrange
            NumberUtils numberUtils = new NumberUtils();

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => numberUtils.SumPrimeNumbers(null));
            Assert.Equal("Array cannot be null (Parameter 'numbers')", exception.Message);
        }
    }
}