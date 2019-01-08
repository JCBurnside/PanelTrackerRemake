namespace PanelTrackerRemake.Tests
{
    using System;
    using PanelTrackerRemake;
    using Xunit;

    [Collection(VaProxyFixtureCollection.Name)]
    public class InvokeTests : IClassFixture<VaProxyFixture>
    {
        private VaProxyFixture data;

        public InvokeTests(VaProxyFixture data)
        {
            this.data = data;
        }

        [Fact]
        public void ProperlyInitialized()
        {
            AssertExtensions.ContainsAll(
            new (string, object)[]
            {
                (EDPTConts.CurrentCommTab, CommsEnum.Chat),
                (EDPTConts.CurrentSystemTab, SystemsEnum.Home),
                (EDPTConts.CurrentTargetTab, TargetPanelEnum.Contacts),
                (EDPTConts.CurrentShipRoleTab, ShipRoleEnum.ALL),
                (EDPTConts.CurrentSrvRoleTab, SrvRolesEnum.Srv),
                (EDPTConts.CurrentPanel, PanelEnum.None)
            },
            this.data.SessionState);
            Assert.IsType<JournalReader>(this.data.SessionState[EDPTConts.Journal]);
        }

        [Fact]
        public void NoContext()
        {
            this.resetData();
            PluginMain.VA_Invoke1(this.data.VaProxy);
            AssertExtensions.ContainsAll(
            new(string, object)[]
            {
                (EDPTConts.CurrentCommTab, CommsEnum.Chat),
                (EDPTConts.CurrentSystemTab, SystemsEnum.Home),
                (EDPTConts.CurrentTargetTab, TargetPanelEnum.Contacts),
                (EDPTConts.CurrentShipRoleTab, ShipRoleEnum.ALL),
                (EDPTConts.CurrentSrvRoleTab, SrvRolesEnum.Srv),
                (EDPTConts.CurrentPanel, PanelEnum.None)
            },
            this.data.SessionState);
            Assert.IsType<JournalReader>(this.data.SessionState[EDPTConts.Journal]);
            Assert.Empty(this.data.VaProxy.ExecutedCommands);
            Assert.Empty(this.data.VaProxy.ConsoleOut);
        }

        private void resetData()
        {
            this.data.VaProxy.SessionState[EDPTConts.CurrentCommTab] = CommsEnum.Chat;
            this.data.VaProxy.SessionState[EDPTConts.CurrentSystemTab] = SystemsEnum.Home;
            this.data.VaProxy.SessionState[EDPTConts.CurrentTargetTab] = TargetPanelEnum.Contacts;
            this.data.VaProxy.SessionState[EDPTConts.CurrentShipRoleTab] = ShipRoleEnum.ALL;
            this.data.VaProxy.SessionState[EDPTConts.CurrentSrvRoleTab] = SrvRolesEnum.Srv;
            this.data.VaProxy.SessionState[EDPTConts.CurrentPanel] = PanelEnum.None;
            if (this.data.SessionState[EDPTConts.Journal] is JournalReader reader)
            {
                reader.Stop();
            }

            this.data.VaProxy.ConsoleOut.Clear();
            this.data.VaProxy.ExecutedCommands.Clear();
            this.data.VaProxy.Context = null;
        }
    }
}