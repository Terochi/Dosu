using Dosu.Game.Online;
using Dosu.Resources;
using osu.Framework.Allocation;
using osu.Framework.IO.Stores;

namespace Dosu.Game
{
    public partial class DosuGameBase : osu.Framework.Game
    {
        [Cached]
        private readonly Client client = new Client();

        protected DosuGameBase()
        {
            Name = @"Dosu";

#if DEBUG
            Name += " (development)";
#endif
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Resources.AddStore(new DllResourceStore(DosuResources.ResourceAssembly));
        }
    }
}
