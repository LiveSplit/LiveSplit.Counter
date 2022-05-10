namespace LiveSplit.UI.Components
{
    public class GlobalCounter : Counter
    {
        public GlobalCounter(int initialValue = 0) : base(initialValue)
        { }

        public override void SetCount(int value)
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 9)
            {
                value = 9;
            }
            base.SetCount(value);
        }

        public override bool Decrement()
        {
            Count -= increment;
            while (Count < 0)
            {
                Count += 10;
            }
            return true;
        }

        public override bool Increment()
        {
            Count = (Count + increment) % 10;
            return true;
        }
    }
}
