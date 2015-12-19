using System.Linq;

namespace Day5
{
    internal sealed class VowelCounter
    {
        private static readonly char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };

        private readonly string _input;

        public VowelCounter(string input)
        {
            _input = input;
        }

        public int Count()
        {
            return Vowels.Sum(vowel => _input.Count(letter => letter == vowel));
        }
    }
}