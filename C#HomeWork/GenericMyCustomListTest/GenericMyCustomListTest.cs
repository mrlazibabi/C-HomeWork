namespace GenericMyCustomListTest
{
    public class MyCustomListTests
    {
        [Fact]
        public void Constructor_InitializesCorrectly()
        {
            var list = new MyCustomList<int>();
            Assert.Equal(0, list.Count);
            Assert.Empty(list.ToArray());
        }

        [Fact]
        public void Add_AddsToNonFullArray()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            Assert.Equal(1, list.Count);
            Assert.Equal(new int[] { 1 }, list.ToArray());
        }

        [Fact]
        public void Add_ResizesArrayWhenFull()
        {
            var list = new MyCustomList<int>();
            for (int i = 0; i < 4; i++) list.Add(i);
            list.Add(4);
            Assert.Equal(5, list.Count);
            Assert.Equal(new int[] { 0, 1, 2, 3, 4 }, list.ToArray());
        }

        [Fact]
        public void Remove_RemovesFirstOccurrence()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(1);
            list.Remove(1);
            Assert.Equal(2, list.Count);
            Assert.Equal(new int[] { 2, 1 }, list.ToArray());
        }

        [Fact]
        public void Remove_DoesNothingIfNotFound()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            list.Remove(2);
            Assert.Equal(1, list.Count);
            Assert.Equal(new int[] { 1 }, list.ToArray());
        }

        [Fact]
        public void Remove_DoesNothingIfEmpty()
        {
            var list = new MyCustomList<int>();
            list.Remove(1);
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void RemoveAt_RemovesFirstItem()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            list.Add(2);
            list.RemoveAt(0);
            Assert.Equal(1, list.Count);
            Assert.Equal(new int[] { 2 }, list.ToArray());
        }

        [Fact]
        public void RemoveAt_RemovesMiddleItem()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveAt(1);
            Assert.Equal(2, list.Count);
            Assert.Equal(new int[] { 1, 3 }, list.ToArray());
        }

        [Fact]
        public void RemoveAt_ThrowsExceptionIfInvalidIndex()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(1));
        }

        [Fact]
        public void Contains_FindsItem()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            list.Add(2);
            Assert.True(list.Contains(2));
        }

        [Fact]
        public void Contains_DoesNotFindItem()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            Assert.False(list.Contains(2));
        }

        [Fact]
        public void Contains_ReturnsFalseIfEmpty()
        {
            var list = new MyCustomList<int>();
            Assert.False(list.Contains(1));
        }

        [Fact]
        public void Clear_ResetsList()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Clear();
            Assert.Equal(0, list.Count);
            Assert.Equal(new int[0], list.ToArray());
        }

        [Fact]
        public void Clear_DoesNothingIfEmpty()
        {
            var list = new MyCustomList<int>();
            list.Clear();
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void ToArray_ReturnsEmptyArrayIfEmpty()
        {
            var list = new MyCustomList<int>();
            var array = list.ToArray();
            Assert.Equal(0, array.Length);
        }

        [Fact]
        public void ToArray_ReturnsCorrectArray()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            list.Add(2);
            var array = list.ToArray();
            Assert.Equal(new int[] { 1, 2 }, array);
        }

        [Fact]
        public void IndexOf_FindsItem()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            list.Add(2);
            Assert.Equal(1, list.IndexOf(2));
        }

        [Fact]
        public void IndexOf_DoesNotFindItem()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            Assert.Equal(-1, list.IndexOf(2));
        }

        [Fact]
        public void IndexOf_ReturnsMinusOneIfEmpty()
        {
            var list = new MyCustomList<int>();
            Assert.Equal(-1, list.IndexOf(1));
        }

        [Fact]
        public void Insert_InsertsAtBeginning()
        {
            var list = new MyCustomList<int>();
            list.Add(2);
            list.Insert(0, 1);
            Assert.Equal(2, list.Count);
            Assert.Equal(new int[] { 1, 2 }, list.ToArray());
        }

        [Fact]
        public void Insert_InsertsAtMiddle()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            list.Add(3);
            list.Insert(1, 2);
            Assert.Equal(3, list.Count);
            Assert.Equal(new int[] { 1, 2, 3 }, list.ToArray());
        }

        [Fact]
        public void Insert_InsertsAtEnd()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            list.Insert(1, 2);
            Assert.Equal(2, list.Count);
            Assert.Equal(new int[] { 1, 2 }, list.ToArray());
        }

        [Fact]
        public void Insert_ResizesWhenFull()
        {
            var list = new MyCustomList<int>();
            for (int i = 0; i < 4; i++) list.Add(i);
            list.Insert(2, 4);
            Assert.Equal(5, list.Count);
            Assert.Equal(new int[] { 0, 1, 4, 2, 3 }, list.ToArray());
        }

        [Fact]
        public void Insert_ThrowsExceptionIfInvalidIndex()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(-1, 2));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(2, 2));
        }

        [Fact]
        public void LastIndexOf_FindsLastItem()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(1);
            Assert.Equal(2, list.LastIndexOf(1));
        }

        [Fact]
        public void LastIndexOf_DoesNotFindItem()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            Assert.Equal(-1, list.LastIndexOf(2));
        }

        [Fact]
        public void LastIndexOf_ReturnsMinusOneIfEmpty()
        {
            var list = new MyCustomList<int>();
            Assert.Equal(-1, list.LastIndexOf(1));
        }

        [Fact]
        public void IsEmpty_ReturnsTrueIfEmpty()
        {
            var list = new MyCustomList<int>();
            Assert.True(list.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ReturnsFalseIfNotEmpty()
        {
            var list = new MyCustomList<int>();
            list.Add(1);
            Assert.False(list.IsEmpty());
        }
    }
}