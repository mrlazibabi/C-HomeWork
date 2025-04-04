using System;
using Xunit;

public class DoublyLinkedListTests
{
    [Fact]
    public void Traverse_EmptyList_ReturnsEmptyString()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        string result = list.Traverse();
        Assert.Equal("", result);
    }

    [Fact]
    public void Traverse_NonEmptyList_ReturnsForwardString()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(2);
        list.InsertTail(3);
        string result = list.Traverse();
        Assert.Equal("1 2 3", result);
    }

    [Fact]
    public void InsertHead_EmptyList_SetsHeadAndTail()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(5);
        Assert.Equal(5, list.Head.DataOfNode);
        Assert.Equal(5, list.Tail.DataOfNode);
        Assert.Equal(1, list.Count());
    }

    [Fact]
    public void InsertHead_NonEmptyList_InsertsAtHead()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertHead(5);
        Assert.Equal(5, list.Head.DataOfNode);
        Assert.Equal(1, list.Tail.DataOfNode);
        Assert.Equal(2, list.Count());
    }

    [Fact]
    public void InsertTail_EmptyList_SetsHeadAndTail()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertTail(4);
        Assert.Equal(4, list.Head.DataOfNode);
        Assert.Equal(4, list.Tail.DataOfNode);
        Assert.Equal(1, list.Count());
    }

    [Fact]
    public void InsertTail_NonEmptyList_InsertsAtTail()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(4);
        Assert.Equal(1, list.Head.DataOfNode);
        Assert.Equal(4, list.Tail.DataOfNode);
        Assert.Equal(2, list.Count());
    }

    [Fact]
    public void InsertAfter_TargetExists_InsertsAfter()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(3);
        list.InsertAfter(1, 2);
        Assert.Equal(3, list.Count());
        Assert.Equal(2, list.GetNode(1).DataOfNode);
        Assert.Equal(3, list.Tail.DataOfNode);
    }

    [Fact]
    public void InsertAfter_TargetAtTail_UpdatesTail()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(3);
        list.InsertAfter(3, 4);
        Assert.Equal(4, list.Tail.DataOfNode);
        Assert.Equal(3, list.Count());
    }

    [Fact]
    public void InsertAfter_TargetNotFound_ThrowsException()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        Assert.Throws<InvalidOperationException>(() => list.InsertAfter(5, 2));
    }

    [Fact]
    public void InsertBefore_TargetExists_InsertsBefore()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(3);
        list.InsertBefore(3, 2);
        Assert.Equal(3, list.Count());
        Assert.Equal(2, list.GetNode(1).DataOfNode);
    }

    [Fact]
    public void InsertBefore_TargetAtHead_UpdatesHead()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertBefore(1, 5);
        Assert.Equal(5, list.Head.DataOfNode);
        Assert.Equal(2, list.Count());
    }

    [Fact]
    public void InsertBefore_TargetNotFound_ThrowsException()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        Assert.Throws<InvalidOperationException>(() => list.InsertBefore(5, 2));
    }

    [Fact]
    public void RemoveHead_EmptyList_DoesNothing()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.RemoveHead();
        Assert.Null(list.Head);
        Assert.Null(list.Tail);
    }

    [Fact]
    public void RemoveHead_SingleNode_ClearsList()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.RemoveHead();
        Assert.Null(list.Head);
        Assert.Null(list.Tail);
    }

    [Fact]
    public void RemoveHead_MultipleNodes_RemovesHead()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertHead(5);
        list.RemoveHead();
        Assert.Equal(1, list.Head.DataOfNode);
        Assert.Equal(1, list.Count());
    }

    [Fact]
    public void RemoveTail_EmptyList_DoesNothing()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.RemoveTail();
        Assert.Null(list.Head);
        Assert.Null(list.Tail);
    }

    [Fact]
    public void RemoveTail_SingleNode_ClearsList()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.RemoveTail();
        Assert.Null(list.Head);
        Assert.Null(list.Tail);
    }

    [Fact]
    public void RemoveTail_MultipleNodes_RemovesTail()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(2);
        list.RemoveTail();
        Assert.Equal(1, list.Tail.DataOfNode);
        Assert.Equal(1, list.Count());
    }

    [Fact]
    public void Remove_EmptyList_DoesNothing()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.Remove(1);
        Assert.Null(list.Head);
    }

    [Fact]
    public void Remove_TargetAtHead_RemovesHead()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(2);
        list.Remove(1);
        Assert.Equal(2, list.Head.DataOfNode);
        Assert.Equal(1, list.Count());
    }

    [Fact]
    public void Remove_TargetAtTail_RemovesTail()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(2);
        list.Remove(2);
        Assert.Equal(1, list.Tail.DataOfNode);
        Assert.Equal(1, list.Count());
    }

    [Fact]
    public void Remove_TargetInMiddle_RemovesNode()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(2);
        list.InsertTail(3);
        list.Remove(2);
        Assert.Equal(2, list.Count());
        Assert.Equal(3, list.Tail.DataOfNode);
    }

    [Fact]
    public void Remove_TargetNotFound_DoesNothing()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.Remove(5);
        Assert.Equal(1, list.Count());
    }

    [Fact]
    public void Search_ValueExists_ReturnsNode()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(2);
        Node node = list.Search(2);
        Assert.NotNull(node);
        Assert.Equal(2, node.DataOfNode);
    }

    [Fact]
    public void Search_ValueNotFound_ReturnsNull()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        Node node = list.Search(5);
        Assert.Null(node);
    }

    [Fact]
    public void GetNode_ValidIndex_ReturnsNode()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(2);
        Node node = list.GetNode(1);
        Assert.NotNull(node);
        Assert.Equal(2, node.DataOfNode);
    }

    [Fact]
    public void GetNode_NegativeIndex_ReturnsNull()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        Node node = list.GetNode(-1);
        Assert.Null(node);
    }

    [Fact]
    public void GetNode_IndexOutOfBounds_ReturnsNull()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        Node node = list.GetNode(5);
        Assert.Null(node);
    }

    [Fact]
    public void GetHead_EmptyList_ReturnsNull()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        Assert.Null(list.GetHead());
    }

    [Fact]
    public void GetHead_NonEmptyList_ReturnsHead()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        Assert.Equal(1, list.GetHead().DataOfNode);
    }

    [Fact]
    public void GetTail_EmptyList_ReturnsNull()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        Assert.Null(list.GetTail());
    }

    [Fact]
    public void GetTail_NonEmptyList_ReturnsTail()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(2);
        Assert.Equal(2, list.GetTail().DataOfNode);
    }

    [Fact]
    public void Count_EmptyList_ReturnsZero()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        Assert.Equal(0, list.Count());
    }

    [Fact]
    public void Count_NonEmptyList_ReturnsCount()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.InsertTail(2);
        Assert.Equal(2, list.Count());
    }

    [Fact]
    public void IsEmpty_EmptyList_ReturnsTrue()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        Assert.True(list.IsEmpty());
    }

    [Fact]
    public void IsEmpty_NonEmptyList_ReturnsFalse()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        Assert.False(list.IsEmpty());
    }

    [Fact]
    public void Clear_EmptyList_DoesNothing()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.Clear();
        Assert.Null(list.Head);
        Assert.Null(list.Tail);
    }

    [Fact]
    public void Clear_NonEmptyList_ClearsList()
    {
        DoublyLinkedList list = new DoublyLinkedList();
        list.InsertHead(1);
        list.Clear();
        Assert.Null(list.Head);
        Assert.Null(list.Tail);
    }

    [Fact]
    public void Node_Constructor_SetsProperties()
    {
        Node node = new Node(5);
        Assert.Equal(5, node.DataOfNode);
        Assert.Null(node.Next);
        Assert.Null(node.Previous);
    }
}