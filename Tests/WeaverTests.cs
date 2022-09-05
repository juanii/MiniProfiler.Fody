using Fody;
using AutoMiniProfiler.Fody;
using System;
using Xunit;
using System.IO;
using System.Xml.Linq;

namespace Tests
{
    public class WeaverTests
    {
        static TestResult testResult;

        private static XElement GetConfiguration(XNamespace defaultNamespace)
        {
            return new XElement(defaultNamespace + "AutoMiniProfiler");
        }

        static WeaverTests()
        {
            var weavingTask = new ModuleWeaver();
            weavingTask.Config = GetConfiguration(weavingTask.Config.GetDefaultNamespace());
            weavingTask.References = string.Empty;
            testResult = weavingTask.ExecuteTestRun(Path.ChangeExtension(nameof(AssemblyToProcess), "dll"), ignoreCodes:new[] { "0x80131869" });
        }

        [Fact]
        public void Test()
        {
            string className = string.Join(".", nameof(AssemblyToProcess), nameof(AssemblyToProcess.TestClass));
            var testClass = testResult.GetInstance(className);
            testClass.TestMethod();
            Assert.Contains(string.Join(".", className, nameof(AssemblyToProcess.TestClass.TestMethod)), testClass.MiniProfilerResult());
        }
    }
}
