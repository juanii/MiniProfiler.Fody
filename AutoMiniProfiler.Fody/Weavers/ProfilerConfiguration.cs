﻿using AutoMiniProfiler.Fody.Filters;

namespace AutoMiniProfiler.Fody.Weavers
{
    public class ProfilerConfiguration
    {
        public ProfilerConfiguration(IProfilerFilter filter, bool shouldProfilerConstructors, bool shouldProfilerProperties)
        {
            Filter = filter;
            ShouldProfilerConstructors = shouldProfilerConstructors;
            ShouldProfilerProperties = shouldProfilerProperties;
        }

        public IProfilerFilter Filter { get; private set; }

        public bool ShouldProfilerConstructors { get; private set; }
        public bool ShouldProfilerProperties { get; private set; }
    }
}