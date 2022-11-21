using System;
using Flare.Battleship.StateTracker.Core;
using Flare.Battleship.StateTracker.Enum;
using Flare.Battleship.StateTracker;

namespace Flare.Battleship.StateTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            var allShipsAdded = false;
            while (!allShipsAdded)
            {
                Console.WriteLine("Add a battle ship with following types Enter");

                Console.WriteLine("DESTROYER = 1,  SUBMARINE = 2, CRUISER = 3, BATTLESHIP = 4, CARRIER = 5");
                var ShipType = Console.ReadLine();

                Ship battleshipType = null;
                
                switch (ShipType)
                {
                    case "1":
                        battleshipType = ShipFactory.CreateShip(ShipTypes.DESTROYER);
                        break;
                    case "2":
                        battleshipType = ShipFactory.CreateShip(ShipTypes.SUBMARINE);
                        break;
                    case "3":
                        battleshipType = ShipFactory.CreateShip(ShipTypes.CARRIER);
                        break;
                    case "4":
                        battleshipType = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
                        break;
                    case "5":
                        battleshipType = ShipFactory.CreateShip(ShipTypes.CARRIER);
                        break;
                    default:
                        Console.WriteLine("Unknown ship type");
                        break;
                }

                Console.WriteLine("Enter start X position");
                var xString = Console.ReadLine();

                Console.WriteLine("Enter start Y position");
                var yString = Console.ReadLine();

                Console.WriteLine("Enter direction Vertical = 1, Horizontal = 2");
                var direction = Console.ReadLine();

                board.AddBattleShip(battleshipType, new Position { X = int.Parse(xString) - 1, Y = int.Parse(yString) - 1 }, direction == "1" ? Direction.VERTICAL : Direction.HORIZONTAL);

                Console.WriteLine("Enter 1 to add another ship, enter 2 to attack");
                var addStr = Console.ReadLine();
                if (addStr != "1") allShipsAdded = true;
            }

            while (!board.IsLost())
            {
                Console.WriteLine("Enter start X position");
                var xString = Console.ReadLine();

                Console.WriteLine("Enter start Y position");
                var yString = Console.ReadLine();

                board.Attack(new Position { X = int.Parse(xString) - 1, Y = int.Parse(yString) - 1 });

            }

            Console.WriteLine("Game is lost !");
        }
    }
}
