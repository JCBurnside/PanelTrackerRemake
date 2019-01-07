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
            new(string, object)[]
            {
                (EDPTConts.CurrentCommTab, CommsEnum.Chat),
                (EDPTConts.CurrentSystemTab, SystemsEnum.Home),
                (EDPTConts.CurrentTargetTab, TargetPanelEnum.Contacts),
                (EDPTConts.CurrentShipRoleTab, ShipRoleEnum.ALL),
                (EDPTConts.CurrentSrvRoleTab, SrvRolesEnum.Helm),
                (EDPTConts.CurrentPanel, PanelEnum.None)
            },
            this.data.SessionState);
            Assert.IsType<JournalReader>(this.data.SessionState[EDPTConts.Journal]);
        }
    }
}
