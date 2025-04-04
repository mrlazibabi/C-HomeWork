using System;
using Xunit;

public class DLL_StackTests
{
    [Fact]
    public void Push_EmptyStack_AddsElement()
    {
        // Arrange
        var stack = new DLL_Stack();

        // Act
        stack.Push(1);

        // Assert
        Assert.False(stack.IsEmpty());
        Assert.Equal(1, stack.Count());
        Assert.Equal(1, stack.Peek());
    }

    [Fact]
    public void Push_MultipleElements_AddsInCorrectOrder()
    {
        // Arrange
        var stack = new DLL_Stack();

        // Act
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Assert
        Assert.Equal(3, stack.Count());
        Assert.Equal(3, stack.Peek()); // Last element pushed should be at the top
    }

    [Fact]
    public void Pop_EmptyStack_ThrowsException()
    {
        // Arrange
        var stack = new DLL_Stack();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Pop_SingleElement_RemovesAndReturnsElement()
    {
        // Arrange
        var stack = new DLL_Stack();
        stack.Push(1);

        // Act
        var result = stack.Pop();

        // Assert
        Assert.Equal(1, result);
        Assert.True(stack.IsEmpty());
        Assert.Equal(0, stack.Count());
    }

    [Fact]
    public void Pop_MultipleElements_RemovesAndReturnsInLIFOOrder()
    {
        // Arrange
        var stack = new DLL_Stack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act
        var result1 = stack.Pop();
        var result2 = stack.Pop();
        var result3 = stack.Pop();

        // Assert
        Assert.Equal(3, result1); // Last in, first out
        Assert.Equal(2, result2);
        Assert.Equal(1, result3);
        Assert.True(stack.IsEmpty());
        Assert.Equal(0, stack.Count());
    }

    [Fact]
    public void Peek_EmptyStack_ThrowsException()
    {
        // Arrange
        var stack = new DLL_Stack();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void Peek_SingleElement_ReturnsElementWithoutRemoving()
    {
        // Arrange
        var stack = new DLL_Stack();
        stack.Push(1);

        // Act
        var result = stack.Peek();

        // Assert
        Assert.Equal(1, result);
        Assert.False(stack.IsEmpty());
        Assert.Equal(1, stack.Count());
    }

    [Fact]
    public void Peek_MultipleElements_ReturnsTopElement()
    {
        // Arrange
        var stack = new DLL_Stack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act
        var result = stack.Peek();

        // Assert
        Assert.Equal(3, result); 
        Assert.Equal(3, stack.Count()); 
    }

    [Fact]
    public void IsEmpty_EmptyStack_ReturnsTrue()
    {
        // Arrange
        var stack = new DLL_Stack();

        // Act & Assert
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void IsEmpty_NonEmptyStack_ReturnsFalse()
    {
        // Arrange
        var stack = new DLL_Stack();
        stack.Push(1);

        // Act & Assert
        Assert.False(stack.IsEmpty());
    }

    [Fact]
    public void Count_EmptyStack_ReturnsZero()
    {
        // Arrange
        var stack = new DLL_Stack();

        // Act & Assert
        Assert.Equal(0, stack.Count());
    }

    [Fact]
    public void Count_NonEmptyStack_ReturnsCorrectCount()
    {
        // Arrange
        var stack = new DLL_Stack();
        stack.Push(1);
        stack.Push(2);

        // Act & Assert
        Assert.Equal(2, stack.Count());
    }
}