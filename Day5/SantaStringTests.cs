using FluentAssertions;
using NUnit.Framework;

namespace Day5
{
    [TestFixture]
    internal sealed class SantaStringTests
    {
        [TestCase("jchzalrnumimnmhp", false)]
        [TestCase("haegwjzuvuyypxyu", false)]
        [TestCase("dvszwmarrgswjxmb", false)]
        [TestCase("ugknbfddgicrmopn", true)]
        [TestCase("aaa", true)]
        public void IsNice_ReturnsExpectedResult(string input, bool expectedResult)
        {
            var santaString = new SantaString(input);

            var isNice = santaString.IsNice();

            isNice.Should().Be(expectedResult);
        }
    }
}