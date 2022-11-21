using System;
using Flare.Battleship.StateTracker.Core;
using Flare.Battleship.StateTracker.Domain;
using Flare.Battleship.StateTracker.Enum;

namespace Flare.Battleship.StateTracker.Core
{
    public static class ShipFactory
    {
        public static Ship CreateShip(ShipTypes shipTypes)
        {
            switch (shipTypes.ToString())
            {
                case nameof(ShipTypes.DESTROYER):
                    return new Destroyer();
                case nameof(ShipTypes.CARRIER):
                    return new Carrier();
                case nameof(ShipTypes.BATTLESHIP):
                    return new Bettleship();
                case nameof(ShipTypes.CRUISER):
                    return new Cruiser();
                case nameof(ShipTypes.SUBMARINE):
                    return new Submarine();
                default:
                    throw new Exception("Unknown ship type");
            }

        }
    }
}
