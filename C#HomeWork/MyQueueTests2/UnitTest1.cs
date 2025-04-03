using Xunit;
using System;

public class QueueTests
{
    [Fact]
    public void Enqueue_ShouldIncreaseCount()
    {
        Queue queue = new Queue();
        queue.Enqueue(10);
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Enqueue_MultipleItems_ShouldAddToTail()
    {
        Queue queue = new Queue();
        queue.Enqueue(10);
        queue.Enqueue(20);
        Assert.Equal(2, queue.Count);
        Assert.Equal(10, queue.Front()); 
    }

    [Fact]
    public void Dequeue_ShouldReturnFirstElementAndDecreaseCount()
    {
        Queue queue = new Queue();
        queue.Enqueue(10);
        queue.Enqueue(20);
        int dequeued = queue.Dequeue();

        Assert.Equal(10, dequeued); 
        Assert.Equal(1, queue.Count);
        Assert.Equal(20, queue.Front()); 
    }

    [Fact]
    public void Dequeue_EmptyQueue_ShouldThrowException()
    {
        Queue queue = new Queue();
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Front_ShouldReturnFirstElementWithoutRemovingIt()
    {
        Queue queue = new Queue();
        queue.Enqueue(10);
        queue.Enqueue(20);
        int front = queue.Front();

        Assert.Equal(10, front); 
        Assert.Equal(2, queue.Count); 
    }

    [Fact]
    public void Front_EmptyQueue_ShouldThrowException()
    {
        Queue queue = new Queue();
        Assert.Throws<InvalidOperationException>(() => queue.Front());
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrueForNewQueue()
    {
        Queue queue = new Queue();
        Assert.True(queue.IsEmpty());
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalseAfterEnqueue()
    {
        Queue queue = new Queue();
        queue.Enqueue(10);
        Assert.False(queue.IsEmpty());
    }

    [Fact]
    public void Count_ShouldReturnZeroForNewQueue()
    {
        Queue queue = new Queue();
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Count_ShouldReturnCorrectCountAfterEnqueue()
    {
        Queue queue = new Queue();
        queue.Enqueue(10);
        queue.Enqueue(20);
        Assert.Equal(2, queue.Count);
    }
}