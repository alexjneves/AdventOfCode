using System.Collections.Generic;

namespace Day3
{
    internal sealed class Position
    {
        public int X { get; }
        public int Y { get; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal class PositionEqualityComparer : IEqualityComparer<Position>
        {
            public bool Equals(Position firstPosition, Position secondPosition)
            {
                return firstPosition.X == secondPosition.X && firstPosition.Y == secondPosition.Y;
            }

            public int GetHashCode(Position position)
            {
                return position.X.GetHashCode() * 17 + position.Y.GetHashCode();
            }
        }
    }
}