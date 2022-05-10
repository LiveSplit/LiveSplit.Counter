using LiveSplit.UI.Components;
using Xunit;

namespace LiveSplit.GlobalCounterTests
{
    public class Increment
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 4)]
        [InlineData(6, 5)]
        [InlineData(7, 6)]
        [InlineData(8, 7)]
        [InlineData(9, 8)]
        [InlineData(10, 9)]
        [InlineData(99, 8)]
        public void WrapsIncrementsOver9ToGlobalRange(int incrementAmount, int expectedCount)
        {
            var counter = new GlobalCounter();
            counter.SetCount(9);
            counter.SetIncrement(incrementAmount);

            counter.Increment();

            Assert.Equal(expectedCount, counter.Count);
        }
    }
}
