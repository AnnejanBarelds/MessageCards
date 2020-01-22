namespace MessageCards
{
    public class TextInput: Input
    {
        public bool IsMultiline { get; set; }

        public TextInput(string initialText = null) : base("TextInput")
        {
            Title = initialText;
        }
    }
}
