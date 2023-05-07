using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    public class MVGSplitFactory : IComponentFactory
    {
        public string ComponentName => "MVG Split";

        public string Description => "AutoSplitter for Multiple Valve Games.";

        public ComponentCategory Category => ComponentCategory.Control;

        public IComponent Create(LiveSplitState state) => new MVGSplitComponent(state);

        public string UpdateName => ComponentName;

        public string UpdateURL => "";

        public string XMLURL => UpdateURL + "";

        public Version Version => Version.Parse("1.0.0");
    }
}