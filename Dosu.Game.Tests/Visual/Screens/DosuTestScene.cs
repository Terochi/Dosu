using osu.Framework.Testing;

namespace Dosu.Game.Tests.Visual.Screens
{
    public abstract partial class DosuTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new DosuTestSceneTestRunner();

        private partial class DosuTestSceneTestRunner : DosuGameBase, ITestSceneTestRunner
        {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete()
            {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}
