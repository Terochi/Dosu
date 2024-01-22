using Dosu.Game.Online;
using Dosu.Resources;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osuTK;

namespace Dosu.Game
{
    public partial class DosuGameBase : osu.Framework.Game
    {
        [Cached]
        private readonly Client client = new Client();

        protected override Container<Drawable> Content { get; }

        protected DosuGameBase()
        {
            Name = @"Dosu";
#if DEBUG
            Name += " (development)";
#endif

            base.Content.Add(Content = new DrawSizePreservingFillContainer
            {
                TargetDrawSize = new Vector2(1366, 768)
            });
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Resources.AddStore(new DllResourceStore(typeof(DosuResources).Assembly));
        }
    }
}
