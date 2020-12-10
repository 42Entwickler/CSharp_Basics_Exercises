using System;
using Xunit;

namespace PriorityQueueMA.Tests
{
    public class MyPrioQueueTests
    {
        #region Error Tests
        [Fact(DisplayName = "Ctr Invalid Size")]
        public void ConstructorErrorTests()
        {
            // Queue must have at least a size of 2
            Assert.Throws<ArgumentOutOfRangeException>(() => new MyPriorityQueue(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new MyPriorityQueue(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => new MyPriorityQueue(1));
        }

        [Fact(DisplayName ="Properties Init Values Tests")]
        public void PropertiesInitTests()
        {
            int size = 5;
            var queue = new MyPriorityQueue(size);
            Assert.Equal(0.0, queue.PercentageFilled);
            Assert.Equal(size, queue.Size);
        }

        [Fact(DisplayName = "Pop On Empty")]
        public void EmptyPopTest()
        {
            var queue = new MyPriorityQueue(2);
            // Can't pop on empty queue
            Assert.Throws<InvalidOperationException>(() => queue.Pop());
            queue.Push("Wolfi");
            Assert.Equal(0.5, queue.PercentageFilled);
            Assert.Equal("Wolfi", queue.Pop());
            Assert.Throws<InvalidOperationException>(() => queue.Pop());
        }

        [Fact(DisplayName = "Push On Full")]
        public void PushOnFullTest()
        {
            // Size of two but have 3 pushes
            var queue = new MyPriorityQueue(2);
            queue.Push("Me");
            queue.Push("You");
            Assert.Throws<InvalidOperationException>(() => queue.Push("Push On Full Outh"));
        }
        #endregion

        [Fact(DisplayName = "Queue Test Normal Only")]
        public void NormalQueueTest()
        {
            // First fill then remove
            string[] data = { "Max", "Muster", "Müller", "Susi", "Mosi", "Gucki", "Hucki" };
            var queue = new MyPriorityQueue(data.Length);
            // Fill it
            foreach (var item in data)
                queue.Push(item);

            // Pop It
            for (int i = 0; i < data.Length; i++)
                Assert.Equal(data[i], queue.Pop());
        }

        [Fact(DisplayName ="Queue Mixed Operations Normal Only")]
        public void FillRemoveMixTest()
        {
            var queue = new MyPriorityQueue(10);
            queue.Push("Max");
            Assert.Equal(0.1, queue.PercentageFilled);
            queue.Push("Susi");
            Assert.Equal(0.2, queue.PercentageFilled);
            Assert.Equal("Max", queue.Pop());
            Assert.Equal(0.1, queue.PercentageFilled);
            queue.Push("Muster");
            Assert.Equal(0.2, queue.PercentageFilled);
            Assert.Equal("Susi", queue.Pop());
            Assert.Equal("Muster", queue.Pop()); // 
            Assert.Equal(0.0, queue.PercentageFilled);
            Assert.Throws<InvalidOperationException>(() => queue.Pop());
            queue.Push("Axl");
            Assert.Equal(0.1, queue.PercentageFilled);
            for (int i = 1; i < queue.Size; i++)
                queue.Push(i.ToString());
            Assert.Throws<InvalidOperationException>(() => queue.Push("Already full not possible"));
            Assert.Equal(1.0, queue.PercentageFilled);
        }

        #region Priority Tests
        [Fact(DisplayName ="Priority Tests")]
        public void PriorityPushTests()
        {
            var queue = new MyPriorityQueue(10);
            queue.Push("Susi");
            queue.Push("VIP MAX", PersonTypes.Vip);
            Assert.Equal("VIP MAX", queue.Pop());
            Assert.Equal("Susi", queue.Pop());
            queue.Push("Normal1");
            queue.Push("Normal2");
            queue.Push("VIP1");
            queue.Push("VIP2");
            queue.Push("Normal3");
            queue.Push("VIP3");
            Assert.Equal("VIP1", queue.Pop());
            Assert.Equal("VIP2", queue.Pop());
            Assert.Equal("VIP3", queue.Pop());
            Assert.Equal("Normal1", queue.Pop());
            Assert.Equal("Normal2", queue.Pop());
            Assert.Equal("Normal3", queue.Pop());
        }
        #endregion
    }
}
