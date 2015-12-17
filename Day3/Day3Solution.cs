using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var santaGrid = new HousesGrid();
            var robotGrid = new HousesGrid();

            for (var i = 0; i < _directions.Length; ++i)
            {
                var direction = _directions[i];

                if (i % 2 == 0)
                {
                    santaGrid.VisitHouse(direction);
                }
                else
                {
                    robotGrid.VisitHouse(direction);
                }
            }

            var visitedHouses = new List<Position>();
            visitedHouses.AddRange(santaGrid.VisitedHouses);
            visitedHouses.AddRange(robotGrid.VisitedHouses);

            var uniqueVisitedHouses = visitedHouses.Distinct(new Position.PositionEqualityComparer());
            return uniqueVisitedHouses.Count();
        }
    }
}
