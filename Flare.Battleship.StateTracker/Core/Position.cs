using System;
namespace Flare.Battleship.StateTracker.Core
{
    public class Position : IEquatable<Position>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public virtual bool Equals(Position? other)
        {
            if (other == null) return false;

            if (X == other.X && Y == other.Y) return true;

            return false;
        }
    }
}
