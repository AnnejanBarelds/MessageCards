using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace MessageCards
{
    public class MessageCard
    {
        private string _summary;

        [JsonProperty("@type")]
        public string Type
        {
            get
            {
                return "MessageCard";
            }
        }

        [JsonProperty("@context")]
        public string Context
        {
            get
            {
                return "https://schema.org/extensions";
            }
        }

        public string Title { get; }

        public string Text { get; set; }
        
        public string ThemeColor { get; set; }

        public string Summary
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_summary))
                {
                    return _summary;
                }
                return string.IsNullOrWhiteSpace(Text) ? Title : null; // We must provide either Text or Summary in the JSON payload
            }
            set
            {
                _summary = value;
            }
        }

        public List<Section> Sections { get; set; }

        [JsonProperty("potentialAction")]
        public List<Action> Actions { get; set; }

        public MessageCard(string title)
        {
            Title = title;
            Sections = new List<Section>();
            Actions = new List<Action>();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
