using LiveSplit.UI.Components;
using System;
using System.Reflection;
using Xunit;

namespace LiveSplit.GlobalCounterTests
{
    public class InitialValue
    {
        [Fact]
        public void CanBeSetInConstructor()
        {
            var expected = 5;
            var counter = new GlobalCounter(expected);

            var actual = GetInitialValue(counter);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldWrapTo0WhenIncrementingPast9AfterSetting()
        {
            var counter = new GlobalCounter(5);

            counter.Increment();
            counter.Increment();
            counter.Increment();
            counter.Increment();
            counter.Increment();

            Assert.Equal(0, counter.Count);
        }

        [Fact]
        public void ShouldWrapTo9WhenDecrementingPast0AfterSetting()
        {
            var counter = new GlobalCounter(3);

            counter.Decrement();
            counter.Decrement();
            counter.Decrement();
            counter.Decrement();

            Assert.Equal(9, counter.Count);
        }

        private static int GetInitialValue(GlobalCounter counter)
        {
            const string fieldName = "initialValue";
            var prop = typeof(Counter).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (prop == null)
            {
                throw new InvalidOperationException($"Could not find \"{fieldName}\" field on {nameof(GlobalCounter)} class.");
            }

            int actual = (int) prop.GetValue(counter);
            return actual;
        }
    }
}
