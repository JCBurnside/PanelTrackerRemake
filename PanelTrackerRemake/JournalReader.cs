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
        private Timer timer;

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
        /// <param name="ignoredEvents">Name of events to be ignored.</param>
        public JournalReader(params string[] ignoredEvents)
            : this(ignoredEvents, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Saved Games\Frontier Developments\Elite Dangerous")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JournalReader"/> class.
        /// </summary>
        /// <param name="ignoredEvents"><see cref="string"/>'s of event name to be ignored.</param>
        /// <param name="dir">Directory of journal files.</param>
        public JournalReader(string[] ignoredEvents, string dir)
        {
        }

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
        public bool IsStarted { get; private set; }

        /// <summary>
        /// Starts the Reader.
        /// </summary>
        public void Start()
        {
            if (this.IsStarted)
            {
                return;
            }

            if (this.timer is null)
            {
                this.timer = new Timer(this.loop, null, Timeout.Infinite, Timeout.Infinite);
            }

            this.IsStarted = true;
            this.timer.Change(0, 100);
        }

        /// <summary>
        /// Stops the journal reader.
        /// </summary>
        public void Stop()
        {
            this.timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

#pragma warning disable SA1300 // Element must begin with upper-case letter
        private void loop(object state)
#pragma warning restore SA1300 // Element must begin with upper-case letter
        {
            // TODO: STUFF.
        }
    }
}