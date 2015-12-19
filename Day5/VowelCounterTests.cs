using FluentAssertions;
using NUnit.Framework;

namespace Day5
{
    [TestFixture]
    internal sealed class VowelCounterTests
    {
        [TestCase("xyz", 0)]
        [TestCase("a", 1)]
        [TestCase("e", 1)]
        [TestCase("i", 1)]
        [TestCase("o", 1)]
        [TestCase("u", 1)]
        [TestCase("aaa", 3)]
        [TestCase("aei", 3)]
        [TestCase("xazegov", 3)]
        [TestCase("aeiouaeiouaeiou", 15)]
        public void Count_ReturnsExpectedValue(string input, int expectedNumberOfVowels)
        {
            var vowelCounter = new VowelCounter(input);

            var actualNumberOfVowels = vowelCounter.Count();

            actualNumberOfVowels.Should().Be(expectedNumberOfVowels);
        }
    }
}