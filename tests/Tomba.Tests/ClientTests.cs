using System;
using System.Collections.Generic;
using Xunit;

namespace Tomba.Tests
{
    public class ClientTests
    {
        [Fact]
        public void Constructor_SetsDefaultEndpoint()
        {
            var client = new Client();
            Assert.Equal("https://api.tomba.io/v1", client.GetEndPoint());
        }

        [Fact]
        public void SetEndPoint_UpdatesEndpoint()
        {
            var client = new Client();
            client.SetEndPoint("https://custom.api.com/v2");
            Assert.Equal("https://custom.api.com/v2", client.GetEndPoint());
        }

        [Fact]
        public void SetKey_AddsToConfig()
        {
            var client = new Client();
            client.SetKey("test-key-123");
            Assert.Equal("test-key-123", client.GetConfig()["key"]);
        }

        [Fact]
        public void SetSecret_AddsToConfig()
        {
            var client = new Client();
            client.SetSecret("test-secret-456");
            Assert.Equal("test-secret-456", client.GetConfig()["secret"]);
        }

        [Fact]
        public void SetSelfSigned_ReturnsSameInstance()
        {
            var client = new Client();
            var result = client.SetSelfSigned(true);
            Assert.Same(client, result);
        }

        [Fact]
        public void FluentApi_Chaining()
        {
            var client = new Client()
                .SetKey("key")
                .SetSecret("secret")
                .SetEndPoint("https://api.tomba.io/v1")
                .SetSelfSigned(false);

            Assert.Equal("key", client.GetConfig()["key"]);
            Assert.Equal("secret", client.GetConfig()["secret"]);
        }
    }
}
