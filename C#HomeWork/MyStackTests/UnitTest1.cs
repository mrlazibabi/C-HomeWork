using System;
using Xunit;

public class MyStackTests
{
    [Fact]
    public void Push_ShouldAddElementToStack()
    {
        // Arrange
        MyStack stack = new MyStack(3);

        // Act
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Assert
        Assert.Equal(3, stack.Count);
        Assert.Equal(3, stack.Peek()); 
    }

    [Fact]
    public void Push_ShouldThrowException_WhenStackIsFull()
    {
        // Arrange
        MyStack stack = new MyStack(2);
        stack.Push(1);
        stack.Push(2);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Push(3));
    }

    [Fact]
    public void Pop_ShouldRemoveAndReturnTopElement()
    {
        // Arrange
        MyStack stack = new MyStack(3);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        // Act & Assert
        Assert.Equal(3, stack.Pop());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.Equal(0, stack.Count); 
    }

    [Fact]
    public void Pop_ShouldThrowException_WhenStackIsEmpty()
    {
        // Arrange
        MyStack stack = new MyStack(2);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_ShouldReturnTopElementWithoutRemovingIt()
    {
        // Arrange
        MyStack stack = new MyStack(3);
        stack.Push(1);
        stack.Push(2);

        // Act & Assert
        Assert.Equal(2, stack.Peek()); 
        Assert.Equal(2, stack.Count); 
    }

    [Fact]
    public void Peek_ShouldThrowException_WhenStackIsEmpty()
    {
        // Arrange
        MyStack stack = new MyStack(3);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void Count_ShouldReturnNumberOfElements()
    {
        // Arrange
        MyStack stack = new MyStack(3);

        // Act
        stack.Push(1);
        stack.Push(2);

        // Assert
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void Reset_ShouldClearStack()
    {
        // Arrange
        MyStack stack = new MyStack(3);
        stack.Push(1);
        stack.Push(2);

        // Act
        stack.Reset();

        // Assert
        Assert.Equal(0, stack.Count);
        Assert.Throws<InvalidOperationException>(() => stack.Peek()); 
    }
}
