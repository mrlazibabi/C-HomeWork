using System;
using Xunit;
using MyCustomList;

public class CustomListTests
{
    [Fact]
    public void Add_ShouldIncreaseCount()
    {
        var list = new CustomList(0);
        list.Add(10);
        list.Add(20);

        Assert.Equal(2, list.Count);
        Assert.Equal(10, list.ToArray()[0]);
        Assert.Equal(20, list.ToArray()[1]);
    }

    [Fact]
    public void Insert_ShouldInsertItemAtCorrectIndex()
    {
        var list = new CustomList(0);
        list.Add(10);
        list.Add(30);
        list.Insert(1, 20);

        Assert.Equal(3, list.Count);
        Assert.Equal(20, list.ToArray()[1]);
    }

    [Fact]
    public void Insert_ShouldThrowException_WhenIndexOutOfRange()
    {
        var list = new CustomList(0);
        list.Add(10);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(-1, 20));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(5, 30));
    }

    [Fact]
    public void Remove_ShouldRemoveExistingItem()
    {
        var list = new CustomList(0);
        list.Add(10);
        list.Add(20);
        list.Remove(10);

        Assert.Equal(1, list.Count);
        Assert.DoesNotContain(10, list.ToArray());
    }

    [Fact]
    public void RemoveAt_ShouldRemoveItemAtIndex()
    {
        var list = new CustomList(0);
        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.RemoveAt(1);

        Assert.Equal(2, list.Count);
        Assert.DoesNotContain(20, list.ToArray());
    }

    [Fact]
    public void RemoveAt_ShouldThrowException_WhenIndexOutOfRange()
    {
        var list = new CustomList(0);
        list.Add(10);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(10));
    }

    [Fact]
    public void Contains_ShouldReturnTrue_WhenItemExists()
    {
        var list = new CustomList(0);
        list.Add(10);
        list.Add(20);

        Assert.True(list.Contains(10));
        Assert.True(list.Contains(20));
    }

    [Fact]
    public void Contains_ShouldReturnFalse_WhenItemNotFound()
    {
        var list = new CustomList(0);
        list.Add(10);
        list.Add(20);

        Assert.False(list.Contains(50));
    }

    [Fact]
    public void IndexOf_ShouldReturnCorrectIndex()
    {
        var list = new CustomList(0);
        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.Equal(1, list.IndexOf(20));
        Assert.Equal(2, list.IndexOf(30));
    }

    [Fact]
    public void IndexOf_ShouldReturnNegativeOne_WhenItemNotFound()
    {
        var list = new CustomList(0);
        list.Add(10);
        list.Add(20);

        Assert.Equal(-1, list.IndexOf(50));
    }

    [Fact]
    public void LastIndexOf_ShouldReturnCorrectIndex()
    {
        var list = new CustomList(0);
        list.Add(10);
        list.Add(20);
        list.Add(10);

        Assert.Equal(2, list.LastIndexOf(10));
    }

    [Fact]
    public void LastIndexOf_ShouldReturnNegativeOne_WhenItemNotFound()
    {
        var list = new CustomList(0);
        list.Add(10);
        list.Add(20);

        Assert.Equal(-1, list.LastIndexOf(50));
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrue_WhenListIsEmpty()
    {
        var list = new CustomList(0);

        Assert.True(list.IsEmpty());
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalse_WhenListHasItems()
    {
        var list = new CustomList(0);
        list.Add(10);

        Assert.False(list.IsEmpty());
    }

    [Fact]
    public void Clear_ShouldRemoveAllItems()
    {
        var list = new CustomList(0);
        list.Add(10);
        list.Add(20);
        list.Clear();

        Assert.Equal(0, list.Count);
        Assert.True(list.IsEmpty());
    }
}
