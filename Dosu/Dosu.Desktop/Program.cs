using Dosu.Game;
using osu.Framework;
using osu.Framework.Platform;

namespace Dosu.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost(@"Dosu"))
            using (osu.Framework.Game game = new DosuGame())
                host.Run(game);
        }
    }
}
