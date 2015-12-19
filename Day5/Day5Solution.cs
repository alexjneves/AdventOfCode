using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;
using FluentAssertions;
using NUnit.Framework;

namespace Day5
{
    public sealed class Day5Solution : IDailyPuzzle
    {
        private const string RawSantaStringsFile = "RawSantaStrings.txt";

        private readonly string[] _rawSantaStrings;

        public Day5Solution()
        {
            _rawSantaStrings = File.ReadAllLines(RawSantaStringsFile);
        }

        public int SolvePart1()
        {
            return _rawSantaStrings.Count(rst => new SantaString(rst).IsNice());
        }

        public int SolvePart2()
        {
            return -1;
        }
    }

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

    [TestFixture]
    internal sealed class SantaStringTests
    {
        [TestCase("jchzalrnumimnmhp", false)]
        [TestCase("haegwjzuvuyypxyu", false)]
        [TestCase("dvszwmarrgswjxmb", false)]
        [TestCase("ugknbfddgicrmopn", true)]
        [TestCase("aaa", true)]

        [TestCase("fvjeprbxyjemyvuq", false)]
        [TestCase("ohnxbykuvvlbbxpf", false)]

        [TestCase("pxdfvcpvwaddrzwv", false)]
        [TestCase("dzspqmttgsuhczto", false)]

        [TestCase("txntccjmqakcoorp", true)]
        [TestCase("dzspqmttgsuhczto", false)]

        [TestCase("mayoqiswqqryvqdi", true)]
        public void IsNice_ReturnsExpectedResult(string input, bool expectedResult)
        {
            var santaString = new SantaString(input);

            var isNice = santaString.IsNice();

            isNice.Should().Be(expectedResult);
        }
    }
}
