using System;
using Microsoft.Extensions.Logging;

namespace FFDCLogger
{
    public static class FFDCJsonLoggerExtensions
    {
        public static ILoggingBuilder AddFFDCJsonLogger(this ILoggingBuilder loggingBuilder)
        {
            if (loggingBuilder == null)
            {
                throw new ArgumentNullException(nameof(AddFFDCJsonLogger));
            }

            loggingBuilder.AddConsole(c => c.FormatterName = FFDCConsoleFormatterName.FFDC)
                .AddConsoleFormatter<FFDCFormatter, FFDCFormatterOptions>();
            return loggingBuilder;
        }

      
    }
}
