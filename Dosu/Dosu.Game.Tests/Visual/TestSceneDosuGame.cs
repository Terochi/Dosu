using Dosu.Game.Tests.Visual.Screens;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Platform;

namespace Dosu.Game.Tests.Visual
{
    [TestFixture]
    public partial class TestSceneDosuGame : DosuTestScene
    {
        private DosuGame game;

        [BackgroundDependencyLoader]
        private void load(GameHost host)
        {
            game = new DosuGame();
            game.SetHost(host);

            AddGame(game);
        }
    }
}
