namespace GenericLinkedListTests
{
    public class SingleLinkedListTests
    {
        [Fact]
        public void Node_Constructor_SetsValueAndNext()
        {
            var node = new Node<int>(5);
            Assert.Equal(5, node.Value);
            Assert.Null(node.Next);
        }

        [Fact]
        public void Constructor_InitializesCorrectly()
        {
            var list = new SingleLinkedList<int>();
            Assert.Null(list.head);
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Add_AddsToEmptyList()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            Assert.Equal(1, list.Count);
            Assert.Equal(1, list.ToArray()[0]);
        }

        [Fact]
        public void Add_AddsToNonEmptyList()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            Assert.Equal(2, list.Count);
            Assert.Equal(new int[] { 1, 2 }, list.ToArray());
        }

        [Fact]
        public void InsertAtHead_AddsToEmptyList()
        {
            var list = new SingleLinkedList<int>();
            list.InsertAtHead(1);
            Assert.Equal(1, list.Count);
            Assert.Equal(1, list.ToArray()[0]);
        }

        [Fact]
        public void InsertAtHead_AddsToNonEmptyList()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.InsertAtHead(0);
            Assert.Equal(2, list.Count);
            Assert.Equal(new int[] { 0, 1 }, list.ToArray());
        }

        [Fact]
        public void Remove_RemovesHead()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Remove(1);
            Assert.Equal(1, list.Count);
            Assert.Equal(2, list.ToArray()[0]);
        }

        [Fact]
        public void Remove_RemovesMiddle()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(2);
            Assert.Equal(2, list.Count);
            Assert.Equal(new int[] { 1, 3 }, list.ToArray());
        }

        [Fact]
        public void Remove_DoesNothingIfNotFound()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Remove(2);
            Assert.Equal(1, list.Count);
            Assert.Equal(1, list.ToArray()[0]);
        }

        [Fact]
        public void Remove_DoesNothingIfEmpty()
        {
            var list = new SingleLinkedList<int>();
            list.Remove(1);
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void RemoveAt_RemovesHead()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.RemoveAt(0);
            Assert.Equal(1, list.Count);
            Assert.Equal(2, list.ToArray()[0]);
        }

        [Fact]
        public void RemoveAt_RemovesMiddle()
        {
            var list = new SingleLinkedList<int>();
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
            var list = new SingleLinkedList<int>();
            list.Add(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(1));
        }

        [Fact]
        public void Contains_FindsItem()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            Assert.True(list.Contains(2));
        }

        [Fact]
        public void Contains_DoesNotFindItem()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            Assert.False(list.Contains(2));
        }

        [Fact]
        public void Contains_ReturnsFalseIfEmpty()
        {
            var list = new SingleLinkedList<int>();
            Assert.False(list.Contains(1));
        }

        [Fact]
        public void Clear_ResetsList()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Clear();
            Assert.Equal(0, list.Count);
            Assert.Null(list.head);
        }

        [Fact]
        public void Clear_DoesNothingIfEmpty()
        {
            var list = new SingleLinkedList<int>();
            list.Clear();
            Assert.Equal(0, list.Count);
            Assert.Null(list.head);
        }

        [Fact]
        public void ToArray_ReturnsEmptyArrayIfEmpty()
        {
            var list = new SingleLinkedList<int>();
            var array = list.ToArray();
            Assert.Equal(0, array.Length);
        }

        [Fact]
        public void ToArray_ReturnsCorrectArray()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            var array = list.ToArray();
            Assert.Equal(new int[] { 1, 2 }, array);
        }

        [Fact]
        public void IndexOf_FindsItem()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            Assert.Equal(1, list.IndexOf(2));
        }

        [Fact]
        public void IndexOf_DoesNotFindItem()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            Assert.Equal(-1, list.IndexOf(2));
        }

        [Fact]
        public void IndexOf_ReturnsMinusOneIfEmpty()
        {
            var list = new SingleLinkedList<int>();
            Assert.Equal(-1, list.IndexOf(1));
        }

        [Fact]
        public void Insert_InsertsAtHead()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Insert(0, 0);
            Assert.Equal(2, list.Count);
            Assert.Equal(new int[] { 0, 1 }, list.ToArray());
        }

        [Fact]
        public void Insert_InsertsAtMiddle()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(3);
            list.Insert(1, 2);
            Assert.Equal(3, list.Count);
            Assert.Equal(new int[] { 1, 2, 3 }, list.ToArray());
        }

        [Fact]
        public void Insert_ThrowsExceptionIfInvalidIndex()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(-1, 2));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(2, 2));
        }

        [Fact]
        public void IsEmpty_ReturnsTrueIfEmpty()
        {
            var list = new SingleLinkedList<int>();
            Assert.True(list.IsEmpty());
        }

        [Fact]
        public void IsEmpty_ReturnsFalseIfNotEmpty()
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            Assert.False(list.IsEmpty());
        }
    }
}