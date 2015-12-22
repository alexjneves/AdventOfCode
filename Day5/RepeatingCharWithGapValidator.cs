using System.Linq;
using System.Text.RegularExpressions;

namespace Day5
{
    internal sealed class RepeatingCharWithGapValidator
    {
        private readonly string _input;

        public RepeatingCharWithGapValidator(string input)
        {
            _input = input;
        }

        public bool ContainsAny()
        {
            var uniqueLetters = _input.Distinct();

            return uniqueLetters.Any(uniqueLetter => Regex.IsMatch(_input, $"{uniqueLetter}.{uniqueLetter}"));
        }
    }
}