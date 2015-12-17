using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    internal sealed class HousesGrid
    {
        private const char Up = '^';
        private const char Down = 'v';
        private const char Left = '<';
        private const char Right = '>';

        private readonly HashSet<Position> _visitedPositions;
        private Position _currentPosition;

        public HousesGrid()
        {
            _visitedPositions = new HashSet<Position>(new Position.PositionEqualityComparer());
            
            _currentPosition = new Position(0, 0);
            _visitedPositions.Add(_currentPosition);
        }

        public void VisitHouse(char direction)
        {
            var x = _currentPosition.X;
            var y = _currentPosition.Y;

            switch (direction)
            {
                case Up:
                    y += 1;
                    break;
                case Down:
                    y -= 1;
                    break;
                case Left:
                    x -= 1;
                    break;
                case Right:
                    x += 1;
                    break;
            }

            _currentPosition = new Position(x, y);
            _visitedPositions.Add(_currentPosition);
        }

        public List<Position> VisitedHouses => _visitedPositions.ToList();
    }
}