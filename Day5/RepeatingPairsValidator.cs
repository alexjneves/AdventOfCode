namespace Day5
{
    internal sealed class RepeatingPairsValidator
    {
        private readonly string _input;

        public RepeatingPairsValidator(string input)
        {
            _input = input;
        }

        public bool ContainsAny()
        {
            for (var i = 0; i < _input.Length - 1; ++i)
            {
                var currentPair = "" + _input[i] + _input[i + 1];

                for (var j = i + 2; j < _input.Length - 1; ++j)
                {
                    var pairToCompare = "" + _input[j] + _input[j + 1];

                    if (currentPair == pairToCompare)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}