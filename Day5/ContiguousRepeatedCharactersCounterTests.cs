using FluentAssertions;
using NUnit.Framework;

namespace Day5
{
    [TestFixture]
    internal sealed class ContiguousRepeatedCharactersCounterTests
    {
        [TestCase("abc", 0)]
        [TestCase("abca", 0)]
        [TestCase("aabc", 1)]
        [TestCase("abcdde", 1)]
        [TestCase("aabbccdd", 4)]
        [TestCase("mayoqiswqqryvqdi", 1)]
        public void Count_ReturnsExpectedValue(string input, int expectedNumberOfCharacters)
        {
            var contiguousRepeatedCharactersCounter = new ContiguousRepeatedCharactersCounter(input);

            var actualNumberOfCharacters = contiguousRepeatedCharactersCounter.Count();

            actualNumberOfCharacters.Should().Be(expectedNumberOfCharacters);
        }
    }
}