using System;
using Xunit;

namespace Tomba.Tests
{
    public class ExceptionTests
    {
        [Fact]
        public void TombaException_WithMessageAndCode()
        {
            var ex = new TombaException("Not found", 404, "{\"error\": \"not found\"}");

            Assert.Equal("Not found", ex.Message);
            Assert.Equal(404, ex.Code);
            Assert.Equal("{\"error\": \"not found\"}", ex.Response);
        }

        [Fact]
        public void TombaException_WithInnerException()
        {
            var inner = new InvalidOperationException("inner error");
            var ex = new TombaException("Outer error", inner);

            Assert.Equal("Outer error", ex.Message);
            Assert.Same(inner, ex.InnerException);
        }

        [Fact]
        public void TombaException_DefaultValues()
        {
            var ex = new TombaException();

            Assert.Null(ex.Code);
            Assert.Null(ex.Response);
        }

        [Fact]
        public void TombaException_IsException()
        {
            var ex = new TombaException("test");
            Assert.IsAssignableFrom<Exception>(ex);
        }
    }
}
