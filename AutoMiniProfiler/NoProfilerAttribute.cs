using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMiniProfiler
{
    /// <summary>
    /// Disables profiling.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class NoProfilerAttribute : Attribute
    {
    }
}
