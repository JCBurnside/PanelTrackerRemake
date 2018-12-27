// Copyright (c) James Burnside. All rights reserved.
// Licensed under the MIT license.

namespace PanelTrackerRemake
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    /// <summary>
    /// Event type for when the journal updates.
    /// </summary>
    /// <param name="line"></param>
    public delegate void JournalUpdated(string line);

    /// <summary>
    /// Used to read the journal in a background thread.
    /// </summary>
    public class JournalReader
    {
        private readonly Regex reg = new Regex("^{.*}$");

        /// <summary>
        /// Sets the vaProxy to use.
        /// </summary>
        public static dynamic VaProxy { set => vaProxy = value; }

        private static dynamic vaProxy;

        /// <summary>
        /// Fires when ever a new entry is made in the journal.
        /// </summary>
        public event JournalUpdated OnJournalUpdate;

        /// <summary>
        /// Gets a value indicating whether or not the Reader has started.
        /// </summary>
        public bool HasStarted => this.hasStarted;

        private Timer timer;
        private bool hasStarted = false;

        public JournalReader(string[] ignoredEvents)
        {
            if(vaProxy)
            {

            }
        }
    }
}