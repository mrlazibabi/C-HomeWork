using System;
using Xunit;

public class MyQueueTests
{
    [Fact]
    public void Enqueue_ShouldAddElementsToQueue() 
    {
        var queue = new MyQueue(3);
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Assert.Equal(10, queue.Front());
        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void Dequeue_ShouldRemoveAndReturnFrontElement()
    {
        var queue = new MyQueue(3);
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);

        Assert.Equal(10, queue.Dequeue());
        Assert.Equal(20, queue.Front());
        Assert.Equal(2, queue.Count);
    }

    [Fact]
    public void Dequeue_ShouldThrowException_WhenQueueIsEmpty()
    {
        var queue = new MyQueue(3);

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Enqueue_ShouldThrowException_WhenQueueIsFull()
    {
        var queue = new MyQueue(2);
        queue.Enqueue(10);
        queue.Enqueue(20);

        Assert.Throws<InvalidOperationException>(() => queue.Enqueue(30));
    }

    [Fact]
    public void Front_ShouldThrowException_WhenQueueIsEmpty()
    {
        var queue = new MyQueue(3);

        Assert.Throws<InvalidOperationException>(() => queue.Front());
    }

    [Fact]
    public void Reset_ShouldEmptyTheQueue()
    {
        var queue = new MyQueue(3);
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Reset();

        Assert.Equal(0, queue.Count);
    }
}
