using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMiniProfiler
{
    /// <summary>
    /// Used by <see cref="ProfilerOnAttribute"/> to target members of a specific visibility level.
    /// </summary>
    public enum ProfilerTarget
    {
        /// <summary>
        /// Public visibility
        /// </summary>
        Public,
        /// <summary>
        /// Internal visibility
        /// </summary>
        Internal,
        /// <summary>
        /// Protected visibility
        /// </summary>
        Protected,
        /// <summary>
        /// Private visibility
        /// </summary>
        Private
    }
}
