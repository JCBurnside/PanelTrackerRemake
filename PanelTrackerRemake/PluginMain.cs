// Copyright (c) James Burnside. All rights reserved.
// Licensed under the MIT license.

namespace PanelTrackerRemake
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Entry point for the plugin.
    /// </summary>
    public class PluginMain
    {
        /// <summary>
        /// Auto dected entry point for invocation of this plugin.
        /// </summary>
        /// <param name="vaProxy">voice attacks provided type.  unknown type.</param>
        public static void VA_Invoke1(dynamic vaProxy)
        {
            Process[] pname = Process.GetProcessesByName("EliteDangerous64");

            if (!pname.Any())
            {
                vaProxy.WriteToLog("Can not proccess.  Elite is not running.", "Red");
                return;
            }
        }
    }
}