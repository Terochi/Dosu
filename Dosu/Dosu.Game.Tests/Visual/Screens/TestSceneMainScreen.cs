using Dosu.Game.Screens;
using NUnit.Framework;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace Dosu.Game.Tests.Visual.Screens
{
    [TestFixture]
    public partial class TestSceneMainScreen : DosuTestScene
    {
        public TestSceneMainScreen()
        {
            Add(new ScreenStack(new MainScreen()) { RelativeSizeAxes = Axes.Both });
        }
    }
}
