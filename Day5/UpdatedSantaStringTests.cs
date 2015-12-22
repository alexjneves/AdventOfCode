using FluentAssertions;
using NUnit.Framework;

namespace Day5
{
    [TestFixture]
    internal sealed class UpdatedSantaStringTests
    {
        [TestCase("xxyxx", true)]
        [TestCase("qjhvhtzxzqqjkmpb", true)]
        [TestCase("uurcxstgmygtbstg", false)]
        [TestCase("ieodomkazucvgmuy", false)]
        public void IsNice_ReturnsExpectedResult(string input, bool expectedResult)
        {
            var updatedSantaString = new UpdatedSantaString(input);

            var isNice = updatedSantaString.IsNice();

            isNice.Should().Be(expectedResult);
        }
    }
}