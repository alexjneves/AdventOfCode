using FluentAssertions;
using NUnit.Framework;

namespace Day4
{
    [TestFixture]
    internal sealed class Md5SubstringHashSolverTests
    {
        [TestCase("abcdef", "00000", 609043)]
        [TestCase("pqrstuv", "00000", 1048970)]
        public void Solve_ReturnsExpectedAnswer(string secretKey, string expectedStartingSubstring, int expectedAnswer)
        {
            var md5SubstringHashSolver = new Md5SubstringHashSolver(secretKey, expectedStartingSubstring);

            var actualAnswer = md5SubstringHashSolver.Solve();

            actualAnswer.Should().Be(expectedAnswer);
        }
    }
}