// Copyright (c) James Burnside. All rights reserved.
// Licensed under the MIT license.

namespace PanelTrackerRemake
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Entry point for the plugin.
    /// </summary>
    public class PluginMain
    {
        /// <summary>
        /// Returns the display name.
        /// </summary>
        /// <returns>Display name.</returns>
        public static string VA_DisplayName()
        {
            return "A remake of CMDR Digital_lights's Elite Dangerous Panel Tracker.";
        }

        /// <summary>
        /// Returns the display info.
        /// </summary>
        /// <returns>display info.</returns>
        public static string VA_DisplayInfo()
        {
            return @"Panel Tracker
            Just a ""simple"" program to track panels.";
        }

        /// <summary>
        /// GUID Id for this extension. DO NOT CHANGE (unless you want to make your own version)!!!!
        /// </summary>
        /// <returns>the guid.</returns>
        public static Guid VA_Id()
        {
            return Guid.Parse("{42B3BF0D-9685-482B-BC92-183BE5A0566C}");
        }

        /// <summary>
        /// Triggered when VA's stop all commands is called.
        /// </summary>
        public static void VA_StopCommand()
        {
        }

        /// <summary>
        /// Called when VA launches.
        /// </summary>
        /// <param name="vaProxy">voice attacks provided type.  unknown type.</param>
        public static void VA_Init1(dynamic vaProxy)
        {
            if (vaProxy.SessionState is Dictionary<string, object> sessionState)
            {
                if (!sessionState.TryAdd(EDPTConts.Journal, new JournalReader()))
                {
                    if (sessionState[EDPTConts.Journal] is JournalReader reader)
                    {
                        reader.Stop();
                    }
                    else
                    {
                        sessionState[EDPTConts.Journal] = new JournalReader();
                    }
                }

                if (!sessionState.TryAdd(EDPTConts.CurrentPanel, PanelEnum.None))
                {
                    sessionState[EDPTConts.CurrentPanel] = PanelEnum.None;
                }

                if (!sessionState.TryAdd(EDPTConts.CurrentTargetTab, null))
                {
                    // TODO: stuff.
                }
            }
        }

        /// <summary>
        /// Called when VA exits... duh...
        /// </summary>
        /// <param name="vaProxy">voice attacks provided type.  unknown type.</param>
        public static void VA_Exit1(dynamic vaProxy)
        {
            if (vaProxy.SessionState[EDPTConts.Journal] is JournalReader reader)
            {
                if (reader.IsStarted)
                {
                    reader.Stop();
                }
            }
        }

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