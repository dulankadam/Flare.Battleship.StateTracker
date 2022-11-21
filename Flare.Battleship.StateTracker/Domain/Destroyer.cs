using System;
using Flare.Battleship.StateTracker.Core;
using Flare.Battleship.StateTracker.Enum;

namespace Flare.Battleship.StateTracker.Domain
{
    public class Destroyer : Ship
    {
        public Destroyer() : base((int)ShipTypes.DESTROYER)
        {

        }
    }
}
