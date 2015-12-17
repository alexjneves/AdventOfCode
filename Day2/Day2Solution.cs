using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    public sealed class Day2Solution
    {
        private const string PresentDimensionsFile = "PresentDimensions.txt";
        private const char DimensionDelimiter = 'x';

        private readonly List<Present> _presents;

        public Day2Solution()
        {
            var presentDimensions = File.ReadAllLines(PresentDimensionsFile);
            _presents = ParsePresentDimensions(presentDimensions);
        }

        public int SolvePart1()
        {
            var amountOfWrappingPaper = 0;

            foreach (var present in _presents)
            {
                var presentSurfaceArea = present.CalculateSurfaceArea();

                var dimensions = new List<int>(3)
                {
                    present.Length,
                    present.Width,
                    present.Height
                };

                var ascendingDimensions = dimensions.OrderByDescending(x => x).Reverse().ToList();
                var areaOfSmallestSide = ascendingDimensions[0] * ascendingDimensions[1];

                amountOfWrappingPaper += presentSurfaceArea;
                amountOfWrappingPaper += areaOfSmallestSide;
            }

            return amountOfWrappingPaper;
        }

        private static List<Present> ParsePresentDimensions(IEnumerable<string> inputDimensions)
        {
            var presents = new List<Present>();

            foreach (var inputDemension in inputDimensions)
            {
                var dimensions = inputDemension.Split(DimensionDelimiter);

                var length = int.Parse(dimensions[0]);
                var width = int.Parse(dimensions[1]);
                var height = int.Parse(dimensions[2]);

                presents.Add(new Present(length, width, height));
            }

            return presents;
        }
    }
}
