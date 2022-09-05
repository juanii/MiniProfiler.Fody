namespace AutoMiniProfiler.Fody {
    public class AppConsts {
        public static readonly string AttributesNamespace = "AutoMiniProfiler";
        public static readonly string ProfilerOnAttributeName = string.Join(".", AttributesNamespace, "ProfilerOnAttribute");
        public static readonly string NoProfilerAttributeName = string.Join(".", AttributesNamespace, "NoProfilerAttribute");

        public static readonly string MiniProfilerName = "MiniProfiler";
        public static readonly string MiniProfilerSharedName = "MiniProfiler.Shared";
    }
}