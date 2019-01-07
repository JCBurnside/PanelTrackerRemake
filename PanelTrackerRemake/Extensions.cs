// Copyright (c) James Burnside. All rights reserved.
// Licensed under the MIT license.

namespace PanelTrackerRemake
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class Extensions
    {
        internal static bool Any(this IEnumerable<string> self, string test) => self.Any(s => s == test);
    }
}