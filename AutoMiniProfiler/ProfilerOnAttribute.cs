using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMiniProfiler
{
    /// <summary>
    /// Enables profiling.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public class ProfilerOnAttribute : Attribute
    {
        /// <summary>
        /// Target visibility
        /// </summary>
        public ProfilerTarget Target { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilerOnAttribute"/>.
        /// </summary>
        public ProfilerOnAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilerOnAttribute"/> with a <see cref="ProfilerTarget"/>.
        /// </summary>
        /// <param name="profilerTarget">The <see cref="ProfilerTarget"/> to use for the target this attribute is applied to.</param>
        public ProfilerOnAttribute(ProfilerTarget profilerTarget)
        {
            Target = profilerTarget;
        }
    }
}
