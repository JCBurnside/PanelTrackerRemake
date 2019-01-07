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
        private static dynamic vaProxy;

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
            PluginMain.vaProxy = vaProxy;
            if (vaProxy.SessionState is Dictionary<string, object> sessionState)
            {
                JournalReader reader = new JournalReader();

                if (!sessionState.TryAdd(EDPTConts.Journal, reader))
                {
                    if (sessionState[EDPTConts.Journal] is JournalReader _reader)
                    {
                        _reader.Stop();
                    }
                    else
                    {
                        sessionState[EDPTConts.Journal] = reader;
                    }
                }

                (sessionState[EDPTConts.Journal] as JournalReader).OnJournalUpdate += HandleJournalEvent;
                sessionState[EDPTConts.CurrentPanel] = PanelEnum.None;
                sessionState[EDPTConts.CurrentTargetTab] = TargetPanelEnum.Contacts;
                sessionState[EDPTConts.CurrentCommTab] = CommsEnum.Chat;
                sessionState[EDPTConts.CurrentShipRoleTab] = ShipRoleEnum.ALL;
                sessionState[EDPTConts.CurrentSystemTab] = SystemsEnum.Home;
                sessionState[EDPTConts.CurrentSrvRoleTab] = SrvRolesEnum.Srv;
                if (new[]
                {
                    EDPTConts.CommsCommand,
                    EDPTConts.ContactsCommand,
                    EDPTConts.RolesCommand,
                    EDPTConts.SystemsCommand,
                    EDPTConts.NextTabCommand,
                    EDPTConts.PrevTabCommand,
                    EDPTConts.UpCommand,
                    EDPTConts.RightCommand,
                    EDPTConts.DownCommand,
                    EDPTConts.LeftCommand,
                    EDPTConts.AcceptCommand,
                    EDPTConts.BackCommand
                }.All(
                    (command) => !vaProxy.CommandExists(command) // this seems like a hack but I don't know a better way.
#pragma warning disable SA1111 // Closing parenthesis must be on line of last parameter
#pragma warning disable SA1009 // Closing parenthesis must be spaced correctly
                ))
#pragma warning restore SA1009 // Closing parenthesis must be spaced correctly
#pragma warning restore SA1111 // Closing parenthesis must be on line of last parameter
                {
                    vaProxy.WriteToLog("One or more of the commands nessacray for proper execution do exist.  Things may not function as expected.", "orange");
                }
            }
            else
            {
                vaProxy.WriteToLog("I DON'T KNOW WHAT WENT WRONG ;-;", "red");
            }
        }

        /// <summary>
        /// Called when VA exits... duh...
        /// </summary>
        /// <param name="vaProxy">voice attacks provided proxy.  unknown type.</param>
        public static void VA_Exit1(dynamic vaProxy)
        {
            if (vaProxy.SessionState[EDPTConts.Journal] is JournalReader reader)
            {
                reader.Stop();
            }
        }

        /// <summary>
        /// Auto dected entry point for invocation of this plugin.
        /// </summary>
        /// <param name="vaProxy">voice attacks provided proxy.  unknown type.</param>
        public static void VA_Invoke1(dynamic vaProxy)
        {
            if (!Process.GetProcessesByName("EliteDangerous64").Any())
            {
                vaProxy.WriteToLog("Can not proccess.  Elite is not running. Stoping journal.", "Red");
                if (vaProxy.SesssionState[EDPTConts.Journal] is JournalReader _reader)
                {
                    _reader.Stop();
                }

                return;
            }

            if (vaProxy.SesssionState[EDPTConts.Journal] is JournalReader reader && !reader.IsStarted)
            {
                reader.Start();
            }

            switch (vaProxy.Context.ToLowerInvariant())
            {
                case "comms":
                case "communications":
                    if (ExecuteCommand(vaProxy, EDPTConts.CommsCommand))
                    {
                        vaProxy.WriteToLog("Execution complete", "green");
                    }

                    break;
                default:
                    return;
            }
        }

        private static bool ExecuteCommandChain(dynamic vaProxy, params string[] commands)
        {
            foreach (string command in commands)
            {
                if (!ExecuteCommand(vaProxy, command))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ExecuteCommand(dynamic vaProxy, string command)
        {
            if (vaProxy.CommandExists(command))
            {
                vaProxy.ExecuteCommand(command, true);
                return true;
            }
            else
            {
                vaProxy.WriteToLog(command + " does not exist.", "red");
                return false;
            }
        }

        private static void HandleJournalEvent(Newtonsoft.Json.Linq.JObject line)
        {
            if (line.Value<string>("Event") == "LoadGame")
            {
                VA_Init1(PluginMain.vaProxy);
            }
        }
    }
}