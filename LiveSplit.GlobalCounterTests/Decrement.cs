using LiveSplit.UI.Components;
using Xunit;

namespace LiveSplit.GlobalCounterTests
{
    public class Decrement
    {
        [Theory]
        [InlineData(1, 9)]
        [InlineData(2, 8)]
        [InlineData(3, 7)]
        [InlineData(4, 6)]
        [InlineData(5, 5)]
        [InlineData(6, 4)]
        [InlineData(7, 3)]
        [InlineData(8, 2)]
        [InlineData(9, 1)]
        [InlineData(10, 0)]
        [InlineData(99, 1)]
        public void WrapsNegativeResultToGlobalRange(int decrementAmount, int expectedCount)
        {
            var counter = new GlobalCounter();
            counter.SetIncrement(decrementAmount);
            
            counter.Decrement();

            Assert.Equal(expectedCount, counter.Count);
        }
    }
}
