using ArrayUtilsDoubleArrayElements;

namespace UnitTestDoubleArrayElement
{
    public class UnitTest1
    {
        [Fact]
        public void DoubleArrayElements_WithValidArray_ReturnsDoubledArray()
        {
            // Arrange
            int[] input = { 1, 2, 3, 4, 5 };
            int[] expected = { 2, 4, 6, 8, 10 };

            // Act
            int[] result = ArrayUtils.DoubleArrayElements(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DoubleArrayElements_WithEmptyArray_ReturnsEmptyArray()
        {
            // Arrange
            int[] input = { };
            int[] expected = { };

            // Act
            int[] result = ArrayUtils.DoubleArrayElements(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DoubleArrayElements_WithNegativeNumbers_ReturnsDoubledValues()
        {
            // Arrange
            int[] input = { -1, -2, -3 };
            int[] expected = { -2, -4, -6 };

            // Act
            int[] result = ArrayUtils.DoubleArrayElements(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DoubleArrayElements_WithZeroes_ReturnsZeroArray()
        {
            // Arrange
            int[] input = { 0, 0, 0 };
            int[] expected = { 0, 0, 0 };

            // Act
            int[] result = ArrayUtils.DoubleArrayElements(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DoubleArrayElements_WithNullArray_ThrowsArgumentNullException()
        {
            // Act & Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => ArrayUtils.DoubleArrayElements(null));
            Assert.Equal("array cannot be null (Parameter 'array')", exception.Message);
        }
    }
}