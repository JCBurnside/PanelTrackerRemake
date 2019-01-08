// Copyright (c) James Burnside. All rights reserved.
// Licensed under the MIT license.

namespace PanelTrackerRemake
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

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
        private Timer timer;
        private DirectoryInfo dir;
        private string[] ignoredEvents;
        private FileInfo currentFile;
        private DateTime lastWriteTime;
        private bool isProcessing = false;
        private long lastPos;

        /// <summary>
        /// Initializes a new instance of the <see cref="JournalReader"/> class.
        /// Uses defualt everything.
        /// </summary>
        public JournalReader()
            : this("Music", "Scan", "Progress", "RefuelAll", "SellExplorationData", "Cargo", "NewCommander")
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
            this.ignoredEvents = ignoredEvents;
            this.dir = new DirectoryInfo(dir);
            if (!this.dir.Exists)
            {
                throw new ArgumentException("Directory doesn't exist", nameof(dir));
            }
        }

        /// <summary>
        /// Fires when ever a new entry is made in the journal.
        /// </summary>
        public event JournalUpdated OnJournalUpdate;

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
            this.IsStarted = false;
            this.timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

#pragma warning disable SA1300 // Element must begin with upper-case letter
        private void loop(object state)
#pragma warning restore SA1300 // Element must begin with upper-case letter
        {
            if (this.isProcessing) return;
            if (this.currentFile == null)
            {
                this.currentFile = this.dir.GetFiles().OrderBy(fi => fi.LastWriteTimeUtc).FirstOrDefault();
                this.lastWriteTime = this.currentFile.LastWriteTimeUtc;
            }
            else
            {
                this.currentFile.Refresh();
                if (this.lastWriteTime < this.currentFile.LastWriteTimeUtc)
                {
                    this.Process();
                }

                if (this.dir.GetFiles().Any(fi => this.currentFile.LastWriteTimeUtc < fi.LastWriteTimeUtc))
                {
                    this.currentFile = this.dir.GetFiles().OrderBy(fi => fi.LastWriteTimeUtc).FirstOrDefault();
                    this.Process();
                }
            }
        }

        private void Process()
        {
            this.isProcessing = true;
            int readLen = 0;
            long seekpos = 0L;
            if (this.lastPos > this.currentFile.Length)
            {
                readLen = (int)this.currentFile.Length;
            }
            else if (this.lastPos < this.currentFile.Length)
            {
                seekpos = this.lastPos;
                readLen = (int)(this.currentFile.Length - this.lastPos);
            }
            else
            {
                this.isProcessing = false;
                return;
            }

            using (FileStream fs = this.currentFile.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                fs.Seek(seekpos, SeekOrigin.Begin);
                byte[] bytes = new byte[readLen];
                int haveRead = 0;
                while (haveRead < readLen)
                {
                    haveRead += fs.Read(bytes, haveRead, readLen - haveRead);
                    fs.Seek(seekpos + haveRead, SeekOrigin.Begin);
                }

                string[] lines = Regex.Split(Encoding.UTF8.GetString(bytes), "\r?\n");
                foreach (string line in lines)
                {
                    JObject jObject = JsonConvert.DeserializeObject<JObject>(line);
                    if (!this.ignoredEvents.Any(jObject.Value<string>("event")))
                    {
                        this.OnJournalUpdate?.Invoke(jObject);
                    }
                }
            }

            this.lastPos = this.currentFile.Length;
            this.isProcessing = false;
        }
    }
}