namespace Day5
{
    internal sealed class SantaString
    {
        private const int MinimumNumberOfVowels = 3;
        private const int MinimumNumberOfContiguousRepeatedCharacters = 1;

        private static readonly string[] ForbiddenSubstrings = { "ab", "cd", "pq", "xy" };

        private readonly VowelCounter _vowelCounter;
        private readonly ContiguousRepeatedCharactersCounter _contiguousRepeatedCharactersCounter;
        private readonly ForbiddenSubstringsValidator _forbiddenSubstringsValidator;

        public SantaString(string input)
        {
            _vowelCounter = new VowelCounter(input);
            _contiguousRepeatedCharactersCounter = new ContiguousRepeatedCharactersCounter(input);
            _forbiddenSubstringsValidator = new ForbiddenSubstringsValidator(input, ForbiddenSubstrings);
        }

        public bool IsNice()
        {
            var containsMinimumNumberOfVowels = _vowelCounter.Count() >= MinimumNumberOfVowels;

            var containsMinimumNumberOfContiguousRepeatedCharacters =
                _contiguousRepeatedCharactersCounter.Count() >= MinimumNumberOfContiguousRepeatedCharacters;

            var doesNotContainsAnyForbiddenStrings = !_forbiddenSubstringsValidator.ContainsAny();

            return containsMinimumNumberOfVowels 
                   && containsMinimumNumberOfContiguousRepeatedCharacters 
                   && doesNotContainsAnyForbiddenStrings;
        }
    }
}