using System;
using Flare.Battleship.StateTracker.Core;
using Flare.Battleship.StateTracker.Enum;

namespace Flare.Battleship.StateTracker.Domain
{
    public class Submarine : Ship
    {
        public Submarine() : base((int)ShipTypes.SUBMARINE)
        {

        }
    }
}
