using Mono.Cecil;

namespace AutoMiniProfiler.Fody.Filters
{
    public interface IProfilerFilter
    {
        bool ShouldAddProfiler(MethodDefinition definition);
    }
}