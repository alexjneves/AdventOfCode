using FluentAssertions;
using NUnit.Framework;

namespace Day5
{
    [TestFixture]
    internal sealed class RepeatingCharWithGapValidatorTests
    {
        [TestCase("xyx", true)]
        [TestCase("aaa", true)]
        [TestCase("xxyxx", true)]
        [TestCase("abcdefeghi", true)]
        [TestCase("qjhvhtzxzqqjkmpb", true)]
        [TestCase("ieodomkazucvgmuy", true)]
        [TestCase("uurcxstgmygtbstg", false)]
        public void ContainsAny_ReturnsExpectedResult(string input, bool expectedContainsResult)
        {
            var repeatingCharWithGapValidator = new RepeatingCharWithGapValidator(input);

            var actualContainsResult = repeatingCharWithGapValidator.ContainsAny();

            actualContainsResult.Should().Be(expectedContainsResult);
        }
    }
}