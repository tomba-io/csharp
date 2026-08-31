using System;
using Xunit;

namespace Tomba.Tests
{
    public class ServiceTests
    {
        private Client CreateTestClient()
        {
            return new Client()
                .SetKey("ta_test_key")
                .SetSecret("ts_test_secret");
        }

        [Fact]
        public void Account_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Account(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Domain_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Domain(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Finder_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Finder(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Verifier_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Verifier(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Sources_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Sources(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Count_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Count(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Status_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Status(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Logs_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Logs(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Keys_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Keys(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void LeadsLists_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new LeadsLists(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void LeadsAttributes_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new LeadsAttributes(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Usage_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Usage(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Phone_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Phone(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Format_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Format(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Similar_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Similar(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Technology_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Technology(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Location_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Location(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Enrichment_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Enrichment(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Reveal_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Reveal(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Flag_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Flag(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Leads_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Leads(client);
            Assert.NotNull(service);
        }

        [Fact]
        public void Bulk_CanBeInstantiated()
        {
            var client = CreateTestClient();
            var service = new Bulk(client);
            Assert.NotNull(service);
        }
    }
}
