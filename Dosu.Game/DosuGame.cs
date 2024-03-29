﻿using Dosu.Game.Screens;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;

namespace Dosu.Game
{
    public partial class DosuGame : DosuGameBase
    {
        private ScreenStack screenStack;

        [BackgroundDependencyLoader]
        private void load()
        {
            Child = screenStack = new ScreenStack { RelativeSizeAxes = Axes.Both };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            screenStack.Push(new MainScreen());
        }
    }
}
