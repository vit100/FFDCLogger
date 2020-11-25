using System;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;

namespace FFDCLogger
{
    public class FFDCFormatter : ConsoleFormatter
    {
        public FFDCFormatter() : base(FFDCConsoleFormatterName.FFDC)
        {
        }

        public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider scopeProvider, TextWriter textWriter)
        {
            var message = logEntry.Formatter(logEntry.State, logEntry.Exception);
            var logMessageModel = new LogMessageModel
            {
                TimeStamp = DateTime.UtcNow,
                LogLevel =  logEntry.LogLevel,
                Message = message,
                Logger = logEntry.Category
            };
            var json = JsonSerializer.Serialize(logMessageModel, typeof(LogMessageModel),
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            textWriter.WriteLine(json);
        }


    }
}