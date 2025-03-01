using ArrayUtilsAreEqualArray;

namespace UnitTestArrayUtils
{
    public class UnitTest1
    {
        [Fact]
        public void Test_AreArraysEqual_WithEqualArrays_ReturnsTrue()
        {
            // Arrange
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4, 5 };

            // Act
            bool result = ArrayUtils.AreArraysEqual(array1, array2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreArraysEqual_WithDifferentArrays_ReturnsFalse()
        {
            // Arrange
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4, 6 };

            // Act
            bool result = ArrayUtils.AreArraysEqual(array1, array2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Test_AreArraysEqual_WithNullArray1_ThrowsArgumentNullException()
        {
            // Arrange
            int[] array1 = null;
            int[] array2 = { 1, 2, 3, 4, 5 };

            // Act & Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => ArrayUtils.AreArraysEqual(array1, array2));
            Assert.Contains("One of the array must not be null", exception.Message);
        }

        [Fact]
        public void Test_AreArraysEqual_WithNullArray2_ThrowsArgumentNullException()
        {
            // Arrange
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = null;

            // Act & Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => ArrayUtils.AreArraysEqual(array1, array2));
            Assert.Contains("One of the array must not be null", exception.Message);
        }

        [Fact]
        public void AreArraysEqual_WithDifferentLengths_ReturnsFalse()
        {
            // Arrange
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3 };

            // Act
            bool result = ArrayUtils.AreArraysEqual(array1, array2);

            // Assert
            Assert.False(result);
        }
    }
}