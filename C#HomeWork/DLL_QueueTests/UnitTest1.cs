using System;
using Xunit;

public class DLL_QueueTests
{
    [Fact]
    public void Enqueue_EmptyQueue_AddsElement()
    {
        // Arrange
        var queue = new DLL_Queue();

        // Act
        queue.Enqueue(1);

        // Assert
        Assert.False(queue.IsEmpty());
        Assert.Equal(1, queue.Count());
        Assert.Equal(1, queue.Front());
    }

    [Fact]
    public void Enqueue_MultipleElements_AddsInCorrectOrder()
    {
        // Arrange
        var queue = new DLL_Queue();

        // Act
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        // Assert
        Assert.Equal(3, queue.Count());
        Assert.Equal(1, queue.Front()); 
    }

    [Fact]
    public void Dequeue_EmptyQueue_ThrowsException()
    {
        // Arrange
        var queue = new DLL_Queue();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Dequeue_SingleElement_RemovesAndReturnsElement()
    {
        // Arrange
        var queue = new DLL_Queue();
        queue.Enqueue(1);

        // Act
        var result = queue.Dequeue();

        // Assert
        Assert.Equal(1, result);
        Assert.True(queue.IsEmpty());
        Assert.Equal(0, queue.Count());
    }

    [Fact]
    public void Dequeue_MultipleElements_RemovesAndReturnsInFIFOOrder()
    {
        // Arrange
        var queue = new DLL_Queue();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        // Act
        var result1 = queue.Dequeue();
        var result2 = queue.Dequeue();
        var result3 = queue.Dequeue();

        // Assert
        Assert.Equal(1, result1); 
        Assert.Equal(2, result2);
        Assert.Equal(3, result3);
        Assert.True(queue.IsEmpty());
        Assert.Equal(0, queue.Count());
    }

    [Fact]
    public void Front_EmptyQueue_ThrowsException()
    {
        // Arrange
        var queue = new DLL_Queue();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => queue.Front());
    }

    [Fact]
    public void Front_SingleElement_ReturnsElementWithoutRemoving()
    {
        // Arrange
        var queue = new DLL_Queue();
        queue.Enqueue(1);

        // Act
        var result = queue.Front();

        // Assert
        Assert.Equal(1, result);
        Assert.False(queue.IsEmpty());
        Assert.Equal(1, queue.Count());
    }

    [Fact]
    public void Front_MultipleElements_ReturnsFrontElement()
    {
        // Arrange
        var queue = new DLL_Queue();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        // Act
        var result = queue.Front();

        // Assert
        Assert.Equal(1, result); 
        Assert.Equal(3, queue.Count()); 
    }

    [Fact]
    public void IsEmpty_EmptyQueue_ReturnsTrue()
    {
        // Arrange
        var queue = new DLL_Queue();

        // Act & Assert
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_NonEmptyQueue_ReturnsFalse()
    {
        // Arrange
        var queue = new DLL_Queue();
        queue.Enqueue(1);

        // Act & Assert
        Assert.False(queue.IsEmpty());
    }

    [Fact]
    public void Count_EmptyQueue_ReturnsZero()
    {
        // Arrange
        var queue = new DLL_Queue();

        // Act & Assert
        Assert.Equal(0, queue.Count());
    }

    [Fact]
    public void Count_NonEmptyQueue_ReturnsCorrectCount()
    {
        // Arrange
        var queue = new DLL_Queue();
        queue.Enqueue(1);
        queue.Enqueue(2);

        // Act & Assert
        Assert.Equal(2, queue.Count());
    }
}