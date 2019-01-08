namespace PanelTrackerRemake.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VaProxyStub
    {
        private readonly Lazy<Dictionary<string, object>> sessionState = new Lazy<Dictionary<string, object>>();
        private readonly Lazy<List<string>> commands = new Lazy<List<string>>();

        internal VaProxyStub()
        {
        }

        public Dictionary<string, object> SessionState => this.sessionState.Value;

        public string Context { get; internal set; } = string.Empty;

        public bool Stopped { get; internal set; } = false;

        public IntPtr MainWindowHandle => IntPtr.Zero;

        internal List<string> Commands { get => this.commands.Value; }

        internal List<string> ExecutedCommands { get; private set; } = new List<string>();

        internal List<(string color, string text)> ConsoleOut { get; private set; } = new List<(string color, string text)>();

        #region Get/Sets Legacy
        public void SetSmallInt(string name, short? value)
        {
        }

        public short? GetSmallInt(string name)
        {
            return null;
        }

        public void SetInt(string name, int? value)
        {
        }

        public int? GetInt(string name)
        {
            return null;
        }

        public void SetText(string name, string value)
        {
        }

        public string GetText(string name)
        {
            return null;
        }

        public void SetDecimal(string name, decimal? value)
        {
        }

        public decimal? GetDecimal(string name)
        {
            return null;
        }

        public void SetBoolean(string name, bool? value)
        {
        }

        public bool? GetBoolean(string name)
        {
            return null;
        }

        public void SetDate(string name, DateTime? value)
        {
        }

        public DateTime? GetDate(string name)
        {
            return null;
        }
        #endregion

        public void ExecuteCommand(string commandName, bool waitForReturn = false)
        {
            this.ExecutedCommands.Add(commandName);
        }

        public bool CommandExists(string commandName) => this.Commands.Any(s => s == commandName);

        public bool CommandActive(string commandName) => false;

        public string[] ExtractPhrases(string phrases) => new string[] { };

        #region Profile Stuff
        public string GetProfileName() => "Test Profile";

        public string GetAuthorTag1() => string.Empty;

        public string GetAuthorTag2() => string.Empty;

        public string GetAuthorTag3() => string.Empty;

        public Guid GetAuthorID() => Guid.NewGuid();

        public Guid GetAuthorProductID() => Guid.NewGuid();
        #endregion

        public void WriteToLog(string value, string color)
        {
            this.ConsoleOut.Add((color, value));
        }

        public string ParseTokens(string value) => string.Empty;

        public System.Version ProxyVersion() => new System.Version(0, 0, 0, 0);

        public System.Version VAVersion() => new Version(0, 0, 0, 0);

        public string PluginPath() => string.Empty;

        public void ResetStopFlag()
        {
            this.Stopped = false;
        }

        public void ClearLog()
        {
            this.ConsoleOut = new List<(string color, string text)>();
        }

        public System.IO.MemoryStream CapturedAudio(int type) => null;
    }
}