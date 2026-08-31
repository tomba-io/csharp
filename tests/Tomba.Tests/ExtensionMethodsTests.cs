using System;
using System.Collections.Generic;
using Xunit;

namespace Tomba.Tests
{
    public class ExtensionMethodsTests
    {
        [Fact]
        public void ToJson_SerializesCorrectly()
        {
            var dict = new Dictionary<string, object>()
            {
                { "key", "value" },
                { "number", 42 }
            };

            var json = dict.ToJson();

            Assert.Contains("\"key\"", json);
            Assert.Contains("\"value\"", json);
            Assert.Contains("42", json);
        }

        [Fact]
        public void ToJson_EmptyDictionary_ReturnsEmptyJson()
        {
            var dict = new Dictionary<string, object>();
            var json = dict.ToJson();
            Assert.Equal("{}", json);
        }

        [Fact]
        public void ToQueryString_SingleParam()
        {
            var dict = new Dictionary<string, object>()
            {
                { "domain", "tomba.io" }
            };

            var qs = dict.ToQueryString();
            Assert.Equal("domain=tomba.io", qs);
        }

        [Fact]
        public void ToQueryString_MultipleParams()
        {
            var dict = new Dictionary<string, object>()
            {
                { "domain", "tomba.io" },
                { "page", 1 }
            };

            var qs = dict.ToQueryString();
            Assert.Contains("domain=tomba.io", qs);
            Assert.Contains("page=1", qs);
            Assert.Contains("&", qs);
        }

        [Fact]
        public void ToQueryString_NullValueSkipped()
        {
            var dict = new Dictionary<string, object>()
            {
                { "domain", "tomba.io" },
                { "empty", null }
            };

            var qs = dict.ToQueryString();
            Assert.Equal("domain=tomba.io", qs);
        }

        [Fact]
        public void ToQueryString_EmptyDictionary()
        {
            var dict = new Dictionary<string, object>();
            var qs = dict.ToQueryString();
            Assert.Equal("", qs);
        }

        [Fact]
        public void ToQueryString_ListParameter()
        {
            var dict = new Dictionary<string, object>()
            {
                { "tags", new List<object> { "tag1", "tag2" } }
            };

            var qs = dict.ToQueryString();
            Assert.Contains("tags[]=tag1", qs);
            Assert.Contains("tags[]=tag2", qs);
        }
    }
}
