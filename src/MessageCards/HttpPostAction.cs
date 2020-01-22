using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MessageCards
{
    public class HttpPostAction: Action, INestableAction
    {
        public enum ContentType
        {
            [EnumMember(Value = "application/json")]
            Json,
            [EnumMember(Value = "application/x-www-form-urlencoded")]
            Form
        }

        public string Target { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ContentType BodyContentType { get; set; }

        public string Body { get; set; }

        public List<Header> Headers { get; set; }

        public HttpPostAction(string name, string target) : base("HttpPOST", name)
        {
            Target = target;
            BodyContentType = ContentType.Json;
            Headers = new List<Header>();
        }

        public void AddHeader(string name, string value)
        {
            Headers.Add(new Header(name, value));
        }
    }
}
