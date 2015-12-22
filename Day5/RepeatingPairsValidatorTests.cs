using FluentAssertions;
using NUnit.Framework;

namespace Day5
{
    [TestFixture]
    internal sealed class RepeatingPairsValidatorTests
    {
        [TestCase("xyxy", true)]
        [TestCase("xxyxx", true)]
        [TestCase("aabcdefgaa", true)]
        [TestCase("uurcxstgmygtbstg", true)]
        [TestCase("qjhvhtzxzqqjkmpb", true)]
        [TestCase("aaaa", true)]
        [TestCase("aaa", false)]
        [TestCase("ieodomkazucvgmuy", false)]
        public void ContainsAny_ReturnsExpectedResult(string input, bool expectedContainsResult)
        {
            var repeatingPairsValidator = new RepeatingPairsValidator(input);

            var actualContainsResult = repeatingPairsValidator.ContainsAny();

            actualContainsResult.Should().Be(expectedContainsResult);
        }
    }
}