using System;
using System.Collections.Generic;
using System.Linq;
using Flare.Battleship.StateTracker.Enum;

namespace Flare.Battleship.StateTracker.Core
{
    public class Board
    {
        public const int BOARD_LENGTH = 10;

        public List<Ship> Battleships { get; set; } = new List<Ship>();
        public List<Position> AttackPositions { get; private set; } = new List<Position>();


        public void AddBattleShip(Ship battleship, Position start, Direction direction)
        {
            if (battleship.Length > BOARD_LENGTH)
                throw new Exception("Ship lenght cannot exceed board length");

            battleship.Fill(start, direction);

            foreach (var ship in Battleships)
            {
                foreach (var position in ship.Positions)
                {
                    if (battleship.Positions.Contains(position))
                    {
                        throw new ArgumentOutOfRangeException("Ship positions are overlapped");
                    }
                }
            }

            Battleships.Add(battleship);
        }

        public bool Attack(Position position)
        {
            var isHit = false;

            foreach (var ship in Battleships)
            {
                if (ship.Attack(position))
                {
                    isHit = true;
                }
            }

            AttackPositions.Add(position);

            return isHit;
        }

        public bool IsLost()
        {
            var isLost = true;
            foreach (var ship in Battleships)
            {

                if (!ship.IsSunk)
                {
                    isLost = false;
                }
            }

            return isLost;

        }
    }
}
