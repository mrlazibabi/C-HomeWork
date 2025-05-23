using System.Collections.Generic;

namespace GenericQueueTests
{
    public class MyQueueTests
    {
        [Fact]
        public void Constructor_InitializesCorrectly()
        {
            var queue = new MyQueue<int>(3);
            Assert.Equal(0, queue.Count); // Kiểm tra giá trị ban đầu của Count
        }

        [Fact]
        public void Enqueue_AddsItemSuccessfully()
        {
            var queue = new MyQueue<int>(3);
            queue.Enqueue(1);
            Assert.Equal(1, queue.Count);
            Assert.Equal(1, queue.Front());
        }

        [Fact]
        public void Enqueue_ThrowsExceptionWhenFull()
        {
            var queue = new MyQueue<int>(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.Throws<InvalidOperationException>(() => queue.Enqueue(3)); // Queue đầy
        }

        [Fact]
        public void Enqueue_WrapsAroundCorrectly()
        {
            var queue = new MyQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue(); // Lấy 1 phần tử ra để rear có thể vòng lại
            queue.Enqueue(3); // rear sẽ vòng lại
            Assert.Equal(2, queue.Count);
            Assert.Equal(2, queue.Front());
        }

        [Fact]
        public void Dequeue_RemovesAndReturnsItem()
        {
            var queue = new MyQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            var item = queue.Dequeue();
            Assert.Equal(1, item);
            Assert.Equal(1, queue.Count);
            Assert.Equal(2, queue.Front());
        }

        [Fact]
        public void Dequeue_ThrowsExceptionWhenEmpty()
        {
            var queue = new MyQueue<int>(3);
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue()); // Queue rỗng
        }

        [Fact]
        public void Dequeue_WrapsAroundCorrectly()
        {
            var queue = new MyQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue(); // front tăng lên
            queue.Enqueue(4); // rear vòng lại
            Assert.Equal(3, queue.Count);
            Assert.Equal(2, queue.Dequeue()); // Kiểm tra front tiếp tục tăng
        }

        [Fact]
        public void Front_ReturnsFirstItem()
        {
            var queue = new MyQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.Equal(1, queue.Front());
            Assert.Equal(2, queue.Count); // Đảm bảo Front không xóa phần tử
        }

        [Fact]
        public void Front_ThrowsExceptionWhenEmpty()
        {
            var queue = new MyQueue<int>(3);
            Assert.Throws<InvalidOperationException>(() => queue.Front()); // Queue rỗng
        }

        [Fact]
        public void Clear_ResetsQueue()
        {
            var queue = new MyQueue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Clear();
            Assert.Equal(0, queue.Count);
            Assert.Throws<InvalidOperationException>(() => queue.Front()); // Đảm bảo queue rỗng
        }

        [Fact]
        public void Clear_WorksWhenQueueIsEmpty()
        {
            var queue = new MyQueue<int>(3);
            queue.Clear(); // Xóa queue rỗng
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void Count_UpdatesCorrectly()
        {
            var queue = new MyQueue<int>(3);
            Assert.Equal(0, queue.Count);
            queue.Enqueue(1);
            Assert.Equal(1, queue.Count);
            queue.Enqueue(2);
            Assert.Equal(2, queue.Count);
            queue.Dequeue();
            Assert.Equal(1, queue.Count);
            queue.Clear();
            Assert.Equal(0, queue.Count);
        }

        [Fact]
        public void Generic_WorksWithDifferentTypes()
        {
            var intQueue = new MyQueue<int>(3);
            intQueue.Enqueue(1);
            Assert.Equal(1, intQueue.Dequeue());

            var stringQueue = new MyQueue<string>(3);
            stringQueue.Enqueue("test");
            Assert.Equal("test", stringQueue.Dequeue());

            var dateQueue = new MyQueue<DateTime>(3);
            var date = new DateTime(2025, 5, 24);
            dateQueue.Enqueue(date);
            Assert.Equal(date, dateQueue.Dequeue());
        }
    }
}