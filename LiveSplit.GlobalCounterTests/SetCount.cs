using LiveSplit.UI.Components;
using Xunit;

namespace LiveSplit.GlobalCounterTests
{
    public class SetCount
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        public void SetsToProvidedCountInGlobalRange(int expectedCount)
        {
            var counter = new GlobalCounter();
            
            counter.SetCount(expectedCount);

            Assert.Equal(expectedCount, counter.Count);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-78)]
        public void RaisesNegativeValueTo0(int negativeValue)
        {
            const int expectedCount = 0;
            var counter = new GlobalCounter();

            counter.SetCount(negativeValue);

            Assert.Equal(expectedCount, counter.Count);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(83)]
        public void LowersValuesOver9To9(int bigValue)
        {
            const int expectedCount = 9;
            var counter = new GlobalCounter();

            counter.SetCount(bigValue);

            Assert.Equal(expectedCount, counter.Count);
        }
    }
}
