using Newtonsoft.Json;

namespace MessageCards
{
    public abstract class Action
    {
        [JsonProperty("@type")]
        public string Type { get; }

        public string Name { get; }

        protected Action(string type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}
