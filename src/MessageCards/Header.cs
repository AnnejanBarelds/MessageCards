namespace MessageCards
{
    public class Header
    {
        public string Name { get; }

        public string Value { get; }

        public Header(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
