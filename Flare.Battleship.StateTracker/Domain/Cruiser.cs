using System;
using Flare.Battleship.StateTracker.Core;
using Flare.Battleship.StateTracker.Enum;

namespace Flare.Battleship.StateTracker.Domain
{
    public class Cruiser : Ship
    {
        public Cruiser() : base((int)ShipTypes.CRUISER)
        {

        }
    }
}
