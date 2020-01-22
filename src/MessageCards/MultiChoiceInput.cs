using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MessageCards
{
    public class MultiChoiceInput: Input
    {
        public enum Style
        {
            [EnumMember(Value = "normal")]
            Normal,
            [EnumMember(Value = "expanded")]
            Expanded
        }

        public List<Choice> Choices { get; set; }

        public bool IsMultiSelect { get; set; }

        [JsonProperty("style")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Style DisplayStyle { get; set; }

        public MultiChoiceInput(string initialText = null) : base("MultiChoiceInput")
        {
            Title = initialText;
            Choices = new List<Choice>();
        }

        public void AddChoice(string display, string value, bool isDefault = false)
        {
            Choices.Add(new Choice(display, value));
            if (isDefault)
            {
                Value = value;
            }
        }
    }
}
