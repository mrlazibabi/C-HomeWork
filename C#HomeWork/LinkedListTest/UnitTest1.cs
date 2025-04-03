using System;
using Xunit;

public class LinkedListTests
{
    private LinkedList list;

    public LinkedListTests()
    {
        list = new LinkedList();
    }

    // Insert Operations
    [Fact]
    public void InsertHead_ShouldInsertNodeAtHead()
    {
        list.InsertHead(10);
        Assert.Equal(10, list.Head.DataOfNode);
    }

    [Fact]
    public void InsertHead_EmptyList_ShouldSetHead()
    {
        list.InsertHead(5);
        Assert.Equal(5, list.Head.DataOfNode);
        Assert.Null(list.Head.Next);
    }

    [Fact]
    public void InsertTail_ShouldInsertNodeAtTail()
    {
        list.InsertHead(10);
        list.InsertTail(20);
        Assert.Equal(20, list.GetTail().DataOfNode);
    }

    [Fact]
    public void InsertTail_EmptyList_ShouldSetHead()
    {
        list.InsertTail(5);
        Assert.Equal(5, list.Head.DataOfNode);
        Assert.Null(list.Head.Next);
    }

    [Fact]
    public void InsertAfter_ShouldInsertNodeCorrectly()
    {
        list.InsertHead(10);
        list.InsertTail(20);
        list.InsertAfter(10, 15);
        Assert.Equal(15, list.Head.Next.DataOfNode);
    }

    [Fact]
    public void InsertAfter_AtTail_ShouldInsertCorrectly()
    {
        list.InsertHead(10);
        list.InsertTail(20);
        list.InsertAfter(20, 30);
        Assert.Equal(30, list.GetTail().DataOfNode);
    }

    [Fact]
    public void InsertAfter_TargetNotFound_ShouldThrow()
    {
        list.InsertHead(10);
        Assert.Throws<InvalidOperationException>(() => list.InsertAfter(20, 15));
    }

    [Fact]
    public void InsertBefore_ShouldInsertNodeBeforeTarget()
    {
        list.InsertHead(10);
        list.InsertTail(20);
        list.InsertBefore(20, 15);
        Assert.Equal(15, list.Head.Next.DataOfNode);
    }

    [Fact]
    public void InsertBefore_EmptyList_ShouldThrow()
    {
        Assert.Throws<InvalidOperationException>(() => list.InsertBefore(10, 5));
    }

    [Fact]
    public void InsertBefore_TargetNotFound_ShouldThrow()
    {
        list.InsertHead(10);
        Assert.Throws<InvalidOperationException>(() => list.InsertBefore(20, 15));
    }

    // Remove Operations
    [Fact]
    public void RemoveHead_ShouldRemoveHeadNode()
    {
        list.InsertHead(10);
        list.InsertTail(20);
        list.RemoveHead();
        Assert.Equal(20, list.Head.DataOfNode);
    }

    [Fact]
    public void RemoveHead_EmptyList_ShouldDoNothing()
    {
        list.RemoveHead();
        Assert.True(list.IsEmpty());
    }

    [Fact]
    public void RemoveHead_SingleNode_ShouldEmptyList()
    {
        list.InsertHead(10);
        list.RemoveHead();
        Assert.Null(list.Head);
    }

    [Fact]
    public void RemoveTail_ShouldRemoveLastNode()
    {
        list.InsertHead(10);
        list.InsertTail(20);
        list.RemoveTail();
        Assert.Null(list.Head.Next);
    }

    [Fact]
    public void RemoveTail_EmptyList_ShouldDoNothing()
    {
        list.RemoveTail();
        Assert.True(list.IsEmpty());
    }

    [Fact]
    public void RemoveTail_SingleNode_ShouldEmptyList()
    {
        list.InsertHead(10);
        list.RemoveTail();
        Assert.Null(list.Head);
    }

    [Fact]
    public void Remove_ShouldRemoveTargetNode()
    {
        list.InsertHead(10);
        list.InsertTail(20);
        list.Remove(10);
        Assert.Equal(20, list.Head.DataOfNode);
    }

    [Fact]
    public void Remove_EmptyList_ShouldDoNothing()
    {
        list.Remove(10);
        Assert.True(list.IsEmpty());
    }

    [Fact]
    public void Remove_ValueNotFound_ShouldDoNothing()
    {
        list.InsertHead(10);
        list.Remove(20);
        Assert.Equal(10, list.Head.DataOfNode);
        Assert.Null(list.Head.Next);
    }

    [Fact]
    public void Remove_MiddleNode_ShouldRemoveCorrectly()
    {
        list.InsertHead(10);
        list.InsertTail(20);
        list.InsertTail(30);
        list.Remove(20);
        Assert.Equal(30, list.Head.Next.DataOfNode);
    }

    // Search/Access Operations
    [Fact]
    public void Search_ShouldReturnCorrectNode()
    {
        list.InsertHead(10);
        list.InsertTail(20);
        var node = list.Search(20);
        Assert.NotNull(node);
        Assert.Equal(20, node.DataOfNode);
    }

    [Fact]
    public void Search_ValueNotFound_ShouldReturnNull()
    {
        list.InsertHead(10);
        var node = list.Search(20);
        Assert.Null(node);
    }

    [Fact]
    public void Search_EmptyList_ShouldReturnNull()
    {
        var node = list.Search(10);
        Assert.Null(node);
    }

    [Fact]
    public void GetNode_ShouldReturnCorrectNode()
    {
        list.InsertHead(10);
        list.InsertTail(20);
        Assert.Equal(20, list.GetNode(1).DataOfNode);
    }

    [Fact]
    public void GetNode_NegativeIndex_ShouldThrow()
    {
        list.InsertHead(10);
        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetNode(-1));
    }

    [Fact]
    public void GetNode_EmptyList_ShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetNode(0));
    }

    [Fact]
    public void GetNode_ShouldThrowForOutOfRange()
    {
        list.InsertHead(10);
        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetNode(2));
    }

    [Fact]
    public void GetHead_EmptyList_ShouldReturnNull()
    {
        Assert.Null(list.GetHead());
    }

    [Fact]
    public void GetTail_EmptyList_ShouldReturnNull()
    {
        Assert.Null(list.GetTail());
    }

    // Utility Operations
    [Fact]
    public void Count_ShouldReturnCorrectCount()
    {
        list.InsertHead(10);
        list.InsertTail(20);
        list.InsertTail(30);
        Assert.Equal(3, list.Count());
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrueForEmptyList()
    {
        Assert.True(list.IsEmpty());
    }

    [Fact]
    public void Clear_ShouldMakeListEmpty()
    {
        list.InsertHead(10);
        list.Clear();
        Assert.True(list.IsEmpty());
    }
}