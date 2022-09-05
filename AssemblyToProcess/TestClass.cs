using System;
using StackExchange.Profiling;

namespace AssemblyToProcess
{
    public class TestClass
    {
        public TestClass()
        {
            MiniProfiler.Settings.ProfilerProvider = new SingletonProfilerProvider();
            MiniProfiler.Start();
        }

        public void TestMethod()
        {
            System.Threading.Thread.Sleep(100);
        }

        public string MiniProfilerResult()
        {
            return MiniProfilerExtensions.RenderPlainText(MiniProfiler.Current);
        }
    }
}
