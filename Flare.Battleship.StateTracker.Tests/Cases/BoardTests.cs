using System;
using Xunit;
using Should;
using Flare.Battleship.StateTracker.Core;
using Flare.Battleship.StateTracker.Enum;
using Flare.Battleship.StateTracker.Domain;

namespace Flare.Battleship.StateTracker.Tests.Cases
{
    public class BoardTests
    {
        [Fact]
        public void ShouldCreateBoard()
        {
            Board board = new Board();
            Assert.NotNull(board);
        }

        [Fact]
        public void ShouldAddBattleship()
        {
            Board board = new Board();
            Ship battleship = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            board.AddBattleShip(battleship, new Position { X = 0, Y = 0 }, Direction.HORIZONTAL);
            board.Battleships.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void ShouldHaveOneSideWithWidthAsOne()
        {
            Board board = new Board();
            Ship battleship = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            board.AddBattleShip(battleship, new Position { X = 0, Y = 0 }, Direction.HORIZONTAL);
            board.Battleships[0].Width.ShouldEqual(1);
        }

        [Fact]
        public void ShouldHaveFilledCarrier()
        {
            Ship battleship = new Carrier();
            battleship.Fill(new Position { X = 0, Y = 0 }, Direction.HORIZONTAL);
            Assert.True(true);
            
        }

        [Fact]
        public void ShouldNotFilledCarrier()
        {
            Ship battleship = new Carrier();
            Assert.Throws<ArgumentOutOfRangeException>(() => battleship.Fill(new Position { X = 6, Y = 0 }, Direction.HORIZONTAL));
        }

        [Fact]
        public void ShouldNotFilledVerticalCarrier()
        {
            Ship battleship = new Carrier();
            Assert.Throws<ArgumentOutOfRangeException>(() => battleship.Fill(new Position { X = 6, Y = 6 }, Direction.VERTICAL));
        }

        [Fact]
        public void ShouldHaveFilledAtEndCarrier()
        {
            Ship battleship = new Carrier();
            battleship.Fill(new Position { X = 5, Y = 9 }, Direction.HORIZONTAL);
            Assert.True(true);

        }

        [Fact]
        public void ShouldNotOverlapHorizontal()
        {
            Board board = new Board();
            Ship battleship1 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            Ship battleship2 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            board.AddBattleShip(battleship1, new Position { X = 0, Y = 0 }, Direction.HORIZONTAL);
            Assert.Throws<ArgumentOutOfRangeException>(() => board.AddBattleShip(battleship2, new Position { X = 3, Y = 0 }, Direction.HORIZONTAL));
            
        }

        [Fact]
        public void ShouldNotThrowHorizontal()
        {
            Board board = new Board();
            Ship battleship1 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            Ship battleship2 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            board.AddBattleShip(battleship1, new Position { X = 0, Y = 0 }, Direction.HORIZONTAL);
            board.AddBattleShip(battleship2, new Position { X = 4, Y = 0 }, Direction.HORIZONTAL);

        }

        [Fact]
        public void ShouldNotOverlapVertical()
        {
            Board board = new Board();
            Ship battleship1 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            Ship battleship2 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            board.AddBattleShip(battleship1, new Position { X = 1, Y = 2 }, Direction.VERTICAL);
            Assert.Throws<ArgumentOutOfRangeException>(() => board.AddBattleShip(battleship2, new Position { X = 0, Y = 3 }, Direction.HORIZONTAL));

        }

        [Fact]
        public void ShouldNotThrowVertical()
        {
            Board board = new Board();
            Ship battleship1 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            Ship battleship2 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            board.AddBattleShip(battleship1, new Position { X = 1, Y = 2 }, Direction.VERTICAL);
            board.AddBattleShip(battleship2, new Position { X = 1, Y = 6 }, Direction.HORIZONTAL);

        }

        [Fact]
        public void ShouldAttack()
        {
            Board board = new Board();
            Ship battleship1 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            Ship battleship2 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            board.AddBattleShip(battleship1, new Position { X = 1, Y = 2 }, Direction.VERTICAL);
            board.AddBattleShip(battleship2, new Position { X = 1, Y = 6 }, Direction.HORIZONTAL);

            bool isHit = board.Attack(new Position { X = 1, Y = 2 });
            Assert.True(isHit);
        }

        [Fact]
        public void ShouldMiss()
        {
            Board board = new Board();
            Ship battleship1 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            Ship battleship2 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            board.AddBattleShip(battleship1, new Position { X = 1, Y = 2 }, Direction.VERTICAL);
            board.AddBattleShip(battleship2, new Position { X = 1, Y = 6 }, Direction.HORIZONTAL);

            bool isHit = board.Attack(new Position { X = 2, Y = 4 });
            Assert.False(isHit);
        }

        [Fact]
        public void ShouldLoss()
        {
            Board board = new Board();
            Ship battleship1 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            board.AddBattleShip(battleship1, new Position { X = 1, Y = 2 }, Direction.VERTICAL);

            board.Attack(new Position { X = 1, Y = 2 });
            board.Attack(new Position { X = 1, Y = 3 });
            board.Attack(new Position { X = 1, Y = 4 });
            board.Attack(new Position { X = 1, Y = 5 });

            bool isLost = board.IsLost();
            Assert.True(isLost);
        }

        [Fact]
        public void ShouldNotLoss()
        {
            Board board = new Board();
            Ship battleship1 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            board.AddBattleShip(battleship1, new Position { X = 1, Y = 2 }, Direction.VERTICAL);

            board.Attack(new Position { X = 1, Y = 2 });
            board.Attack(new Position { X = 1, Y = 3 });
            board.Attack(new Position { X = 1, Y = 4 });
            board.Attack(new Position { X = 1, Y = 6 });

            bool isLost = board.IsLost();
            Assert.False(isLost);
        }

        [Fact]
        public void ShouldNotLossWithMultipleShips()
        {
            Board board = new Board();
            Ship battleship1 = ShipFactory.CreateShip(ShipTypes.BATTLESHIP);
            Ship battleship2 = ShipFactory.CreateShip(ShipTypes.CARRIER);
            board.AddBattleShip(battleship1, new Position { X = 1, Y = 2 }, Direction.VERTICAL);
            board.AddBattleShip(battleship2, new Position { X = 2, Y = 2 }, Direction.VERTICAL);

            board.Attack(new Position { X = 1, Y = 2 });
            board.Attack(new Position { X = 1, Y = 3 });
            board.Attack(new Position { X = 1, Y = 4 });
            board.Attack(new Position { X = 1, Y = 5 });

            board.Attack(new Position { X = 2, Y = 2 });
            board.Attack(new Position { X = 2, Y = 3 });
            board.Attack(new Position { X = 2, Y = 4 });
            board.Attack(new Position { X = 2, Y = 5 });
            board.Attack(new Position { X = 2, Y = 6 });

            bool isLost = board.IsLost();
            Assert.True(isLost);
        }


    }
}
