// Copyright (c) James Burnside. All rights reserved.
// Licensed under the MIT license.

namespace PanelTrackerRemake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    /// <summary>
    /// Event type for when the journal updates.
    /// </summary>
    /// <param name="line">Line that has parsed into a <see cref="Newtonsoft.Json.Linq.JObject"/>.</param>
    public delegate void JournalUpdated(Newtonsoft.Json.Linq.JObject line);

    /// <summary>
    /// Used to read the journal in a background thread.
    /// </summary>
    public class JournalReader
    {
        private static dynamic vaProxy;

        private readonly Regex reg;

        /// <summary>
        /// Fires when ever a new entry is made in the journal.
        /// </summary>
        public event JournalUpdated OnJournalUpdate;

        /// <summary>
        /// Sets the vaProxy to use.
        /// </summary>
        public static dynamic VaProxy { set => vaProxy = value; }

        /// <summary>
        /// Gets a value indicating whether or not the Reader has started.
        /// </summary>
        public bool HasStarted => this.hasStarted;

        private Timer timer;
        private bool hasStarted = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="JournalReader"/> class.
        /// Uses defualt everything.
        /// </summary>
        public JournalReader()
            : this(new[] { "Meusic", "Scan", "Progress", "RefuelAll", "SellExplorationData", "Cargo", "NewCommander" })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JournalReader"/> class.
        /// Uses default regex.
        /// </summary>
        /// <param name="ignoredEvents"></param>
        public JournalReader(string[] ignoredEvents)
            : this(ignoredEvents,Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Saved Games\Frontier Developments\Elite Dangerous")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ignoredEvents"></param>
        /// <param name="dir"></param>
        public JournalReader(string[] ignoredEvents, string dir)
        {
        }
    }
}