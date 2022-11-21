using System;
using System.Collections.Generic;
using Flare.Battleship.StateTracker.Core;
using Should.Core.Assertions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Flare.Battleship.StateTracker.Tests.Cases
{
    public class PositionTests
    {
        [Fact]
        public void ShouldContainPoint()
        {
            var p1 = new Position { X = 1, Y = 2 };
            var p2 = new Position { X = 1, Y = 2 };
            var p3 = new Position { X = 1, Y = 2 };
            var points = new List<Position>
            {
                p1, p2
            };
            Assert.True(points.Contains(p3));
        }
    }
}
