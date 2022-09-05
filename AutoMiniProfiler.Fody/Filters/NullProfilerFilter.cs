using Mono.Cecil;

namespace AutoMiniProfiler.Fody.Filters
{
    internal class NullProfilerFilter : IProfilerFilter
    {
        public static readonly NullProfilerFilter Instance = new NullProfilerFilter();

        private NullProfilerFilter()
        {
        }

        public bool ShouldAddProfiler(MethodDefinition definition)
        {
            return true;
        }
    }
}