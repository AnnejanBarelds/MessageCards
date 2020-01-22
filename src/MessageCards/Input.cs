using Newtonsoft.Json;
using System;

namespace MessageCards
{
    public abstract class Input
    {
        [JsonProperty("@type")]
        public string Type { get; }

        public string Title { get; set; }

        public string Id { get; set; }

        public bool IsRequired { get; set; }

        public string Value { get; set; }

        protected Input(string type)
        {
            Type = type;
            Id = Guid.NewGuid().ToString();
        }

        public string GetValueReference()
        {
            return $"{{{{{Id}.value}}}}";
        }
    }
}
