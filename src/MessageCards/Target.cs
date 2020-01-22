using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MessageCards
{
    public class Target
    {
        public enum Os
        {
            [EnumMember(Value = "default")]
            Default,

            [EnumMember(Value = "windows")]
            Windows,

            [EnumMember(Value = "iOS")]
            iOS,

            [EnumMember(Value = "android")]
            Android,
        }

        [JsonProperty("Os")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Os TargetOs { get; }

        public string Uri { get; }

        public Target(string uri, Os os = Os.Default)
        {
            TargetOs = os;
            Uri = uri;
        }
    }
}
