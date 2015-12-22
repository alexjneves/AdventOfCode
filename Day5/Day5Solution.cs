using System.IO;
using System.Linq;
using Common;

namespace Day5
{
    public sealed class Day5Solution : IDailyPuzzle
    {
        private const string RawSantaStringsFile = "RawSantaStrings.txt";

        private readonly string[] _rawSantaStrings;

        public Day5Solution()
        {
            _rawSantaStrings = File.ReadAllLines(RawSantaStringsFile);
        }

        public int SolvePart1()
        {
            return _rawSantaStrings.Count(rst => new SantaString(rst).IsNice());
        }

        public int SolvePart2()
        {
            return _rawSantaStrings.Count(rst => new UpdatedSantaString(rst).IsNice());
        }
    }
}
