namespace PanelTrackerRemake.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    public class VaProxyFixture : IDisposable
    {
        public VaProxyFixture()
        {
            this.VaProxy = new VaProxyStub();
            PluginMain.VA_Init1(this.VaProxy);
        }

        internal VaProxyStub VaProxy { get; private set; }

        internal Dictionary<string, object> SessionState { get => this.VaProxy?.SessionState; }

        public void Dispose()
        {
            PluginMain.VA_Exit1(this.VaProxy);
        }
    }

#pragma warning disable SA1402 // File may only contain a single class
    [CollectionDefinition(Name)]
    public class VaProxyFixtureCollection : ICollectionFixture<VaProxyFixture>
    {
        internal const string Name = "Va Proxy Collection";
    }
#pragma warning restore SA1402 // File may only contain a single class
}
