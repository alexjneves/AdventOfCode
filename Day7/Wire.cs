namespace Day7
{
    internal sealed class Wire
    {
        public string Identifier { get; }

        public Wire(string identifier)
        {
            Identifier = identifier.ToLower();
        }
    }
}