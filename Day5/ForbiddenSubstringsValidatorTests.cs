using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Day5
{
    [TestFixture]
    internal sealed class ForbiddenSubstringsValidatorTests
    {
        [TestCase("abc", new[] { "d" }, false)]
        [TestCase("abc", new[] { "ac" }, false)]
        [TestCase("abc", new[] { "d", "e" }, false)]
        [TestCase("abc", new[] { "c" }, true)]
        [TestCase("abc", new[] { "abc" }, true)]
        [TestCase("abc", new[] { "d", "a" }, true)]
        public void ContainsAny_ReturnsExpectedResult(string input, IEnumerable<string> forbiddenSubstrings, bool expectedContainsResult)
        {
            var forbiddenSubstringsValidator = new ForbiddenSubstringsValidator(input, forbiddenSubstrings);

            var containsAnyForbiddenSubstrings = forbiddenSubstringsValidator.ContainsAny();

            containsAnyForbiddenSubstrings.Should().Be(expectedContainsResult);
        }
    }
}