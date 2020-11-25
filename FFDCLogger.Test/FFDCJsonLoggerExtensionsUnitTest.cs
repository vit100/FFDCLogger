using System;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace FFDCLogger.Test
{
    public class FFDCJsonLoggerExtensionsUnitTest
    {
        [Fact]
        public void ShouldHaveExtensionAddFFDCJsonLogger()
        {
            Host.CreateDefaultBuilder().ConfigureLogging(loggingBuilder =>
            {
               loggingBuilder.AddFFDCJsonLogger();
                Assert.True(true);
            }).RunConsoleAsync();
        }

        [Fact]
        public void ShouldAddFFDCFormatter()
        {
            Host.CreateDefaultBuilder().ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder.AddFFDCJsonLogger();
                var formatter = loggingBuilder.Services.First(s => s.ImplementationType == typeof(FFDCFormatter));
                Assert.True(formatter != null);
            }).RunConsoleAsync();
        }

        [Fact]
        public void ShouldThrowIfCalledWithNullParam()
        {
            Host.CreateDefaultBuilder().ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder = null;

                Assert.Throws<ArgumentNullException>(() => loggingBuilder.AddFFDCJsonLogger());
            }).RunConsoleAsync();

        }
    }
}
