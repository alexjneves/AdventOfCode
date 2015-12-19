using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    internal sealed class ForbiddenSubstringsValidator
    {
        private readonly string _input;
        private readonly IEnumerable<string> _forbiddenSubstrings;

        public ForbiddenSubstringsValidator(string input, IEnumerable<string> forbiddenSubstrings)
        {
            _input = input;
            _forbiddenSubstrings = forbiddenSubstrings;
        }

        public bool ContainsAny()
        {
            return _forbiddenSubstrings.Any(forbiddenString => _input.Contains(forbiddenString));
        }
    }
}