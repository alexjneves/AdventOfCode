using FluentAssertions;
using NUnit.Framework;

namespace Day3
{
    [TestFixture]
    public class HousesGridTests
    {
        [TestCase(">", 2)]
        [TestCase("><", 2)]
        [TestCase("^v", 2)]
        [TestCase("<", 2)]
        [TestCase("<^>v", 4)]
        public void visitHouses_WithGivenDirections_VisitsExpectedNumberOfUniqueHouses(string directions, int expectedNumberOfHousesVisited)
        {
            var housesGrid = new HousesGrid();

            foreach (var direction in directions)
            {
                housesGrid.VisitHouse(direction);
            }

            var visitedHouses = housesGrid.VisitedHouses;

            visitedHouses.Count.Should().Be(expectedNumberOfHousesVisited);
        }
    }
}