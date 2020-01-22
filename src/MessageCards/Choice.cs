namespace MessageCards
{
    public class Choice
    {
        public string Display { get; }
        public string Value { get; }

        public Choice(string display, string value)
        {
            Display = display;
            Value = value;
        }
    }
}
