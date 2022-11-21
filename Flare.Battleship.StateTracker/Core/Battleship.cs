using System;
using System.Collections.Generic;
using Flare.Battleship.StateTracker.Enum;

namespace Flare.Battleship.StateTracker.Core
{
    public abstract class Ship
    {
        public int Length { get; set; }
        public readonly int Width = 1;

        public List<Position> Positions { get; private set; } = new List<Position>();
        public List<Position> HitPositions { get; private set; } = new List<Position>();

        public bool IsSunk { get; set; }

        public Ship(int length)
        {
            this.Length = length;
        }

        public void Fill(Position start, Direction direction)
        {
            if (start.X >= 10 || start.Y >= 10)
                throw new ArgumentOutOfRangeException("start position should be within the board");



            var positions = new List<Position>();

            for (int i = 0; i < Length; i++)
            {
                Position position = null;
                if (direction == Direction.VERTICAL)
                {
                    position = new Position { X = start.X, Y = start.Y + i };
                }
                else
                {
                    position = new Position { X = start.X + i, Y = start.Y };
                }

                if (position.X >= 10 || position.Y >= 10)
                    throw new ArgumentOutOfRangeException("position should be within the board");

                positions.Add(position);
            }

            Positions = positions;
        }

        public bool Attack(Position position)
        {
            if (Positions.Contains(position))
            {
                HitPositions.Add(position);

                if (HitPositions.Count == Positions.Count)
                {
                    IsSunk = true;
                }

                return true;
            }

            return false;
        }
    }
}
