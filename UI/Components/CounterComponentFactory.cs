using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    public class CounterComponentFactory : IComponentFactory
    {
        public string ComponentName => "Global Counter";

        public string Description => "Modified LiveSplit.Counter tuned specifically for tracking your global count in The Legend of Zelda on NES.";

        public ComponentCategory Category => ComponentCategory.Other;

        public IComponent Create(LiveSplitState state) => new CounterComponent(state);

        public string UpdateName => ComponentName;

        public string XMLURL => string.Empty;

        public string UpdateURL => "http://livesplit.org/update/";

        public Version Version => Version.Parse("1.8.19");
    }
}
