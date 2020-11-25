using System;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;

namespace FFDCLogger
{
    public class LogMessageModel
    {
        [JsonPropertyName("ts")]
        public DateTime TimeStamp { get; set; }

        [JsonPropertyName("sev")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public LogLevel LogLevel { get; set; }

        [JsonPropertyName("msg")]
        public string Message { get; set; }

        [JsonPropertyName("logger")]
        public string Logger { get; set; }
    }
}
