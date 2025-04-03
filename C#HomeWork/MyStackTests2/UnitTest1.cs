using Xunit;
using System;

public class MyStackTests
{
    [Fact]
    public void Push_ShouldIncreaseCount()
    {
        MyStack stack = new MyStack();
        stack.Push(10);
        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Pop_ShouldReturnLastElementAndDecreaseCount()
    {
        MyStack stack = new MyStack();
        stack.Push(10);
        stack.Push(20);
        int popped = stack.Pop();

        Assert.Equal(20, popped);
        Assert.Equal(1, stack.Count);
    }

    [Fact]
    public void Peek_ShouldReturnLastElementWithoutRemovingIt()
    {
        MyStack stack = new MyStack();
        stack.Push(10);
        stack.Push(20);
        int peeked = stack.Peek();

        Assert.Equal(20, peeked);
        Assert.Equal(2, stack.Count);
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrueForNewStack()
    {
        MyStack stack = new MyStack();
        Assert.True(stack.IsEmpty());
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalseAfterPush()
    {
        MyStack stack = new MyStack();
        stack.Push(10);
        Assert.False(stack.IsEmpty());
    }

    [Fact]
    public void Pop_ShouldThrowException_WhenStackIsEmpty()
    {
        MyStack stack = new MyStack();
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void Peek_ShouldThrowException_WhenStackIsEmpty()
    {
        MyStack stack = new MyStack();
        Assert.Throws<InvalidOperationException>(() => stack.Peek());
    }

    [Fact]
    public void Reset_ShouldMakeStackEmpty()
    {
        MyStack stack = new MyStack();
        stack.Push(10);
        stack.Reset();

        Assert.True(stack.IsEmpty());
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Reset_EmptyStack_ShouldRemainEmpty()
    {
        MyStack stack = new MyStack();
        stack.Reset();

        Assert.True(stack.IsEmpty());
        Assert.Equal(0, stack.Count);
    }
}