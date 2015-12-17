using System.IO;
using Common;

namespace Day3
{
    public sealed class Day3Solution : IDailyPuzzle
    {
        private const string HouseDirectionFile = "HouseDirections.txt";

        private readonly string _directions;

        public Day3Solution()
        {
            _directions = File.ReadAllText(HouseDirectionFile);
        }

        public int SolvePart1()
        {
            var housesGrid = new HousesGrid();

            foreach (var direction in _directions)
            {
                housesGrid.VisitHouse(direction);
            }

            var vistedHouses = housesGrid.VisitedHouses;

            return vistedHouses.Count;
        }

        public int SolvePart2()
        {
            return -1;
        }
    }
}
