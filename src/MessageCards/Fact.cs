namespace MessageCards
{
    public class Fact
    {
        public string Name { get; }

        public string Value { get; }

        public Fact(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
