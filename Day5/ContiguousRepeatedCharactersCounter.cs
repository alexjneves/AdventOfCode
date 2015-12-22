using System.Linq;

namespace Day5
{
    internal sealed class ContiguousRepeatedCharactersCounter
    {
        private readonly string _input;

        public ContiguousRepeatedCharactersCounter(string input)
        {
            _input = input;
        }

        public int Count()
        {
            var distinctCharacters = _input.Distinct();

            return distinctCharacters.Count(distinctCharacter => _input.Contains($"{distinctCharacter}{distinctCharacter}"));
        }
    }
}