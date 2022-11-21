using System;
using Flare.Battleship.StateTracker.Core;
using Flare.Battleship.StateTracker.Enum;

namespace Flare.Battleship.StateTracker.Domain
{
    public class Carrier : Ship
    {
        public Carrier() : base((int)ShipTypes.CARRIER)
        {

        }
    }
}
