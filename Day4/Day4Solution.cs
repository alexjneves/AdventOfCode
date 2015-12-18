using Common;

namespace Day4
{
    public sealed class Day4Solution : IDailyPuzzle
    {
        private const string SecretKey = "ckczppom";
        private const string ExpectedStartingSubstring = "00000";

        public int SolvePart1()
        {
            var md5SubstringHashSolver = new Md5SubstringHashSolver(SecretKey, ExpectedStartingSubstring);

            return md5SubstringHashSolver.Solve();
        }

        public int SolvePart2()
        {
            return -1;
        }
    }
}
