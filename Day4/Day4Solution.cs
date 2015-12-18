using Common;

namespace Day4
{
    public sealed class Day4Solution : IDailyPuzzle
    {
        private const string SecretKey = "ckczppom";
        private const string Part1ExpectedStartingSubstring = "00000";
        private const string Part2ExpectedStartingSubstring = "000000";

        public int SolvePart1()
        {
            var md5SubstringHashSolver = new Md5SubstringHashSolver(SecretKey, Part1ExpectedStartingSubstring);

            return md5SubstringHashSolver.Solve();
        }

        public int SolvePart2()
        {
            var md5SubstringHashSolver = new Md5SubstringHashSolver(SecretKey, Part2ExpectedStartingSubstring);

            return md5SubstringHashSolver.Solve();
        }
    }
}
