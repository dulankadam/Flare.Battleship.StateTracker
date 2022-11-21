using System;
using Flare.Battleship.StateTracker.Core;
using Flare.Battleship.StateTracker.Enum;

namespace Flare.Battleship.StateTracker.Domain
{
    public class Bettleship : Ship
    {
        public Bettleship() : base((int)ShipTypes.BATTLESHIP)
        {

        }
    }
}
