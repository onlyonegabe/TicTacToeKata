using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToeKata.Tests
{
    [TestClass]
    public class TicTacToeKataTests
    {
        private TicTacToeGame game;
        private Board board = new Board(3, 3);

        [TestInitialize]
        public void SetUp()
        {
            game = new TicTacToeGame(board);
        }

        [TestMethod]
        public void FirstPlayerMustBeX()
        {
            // Act
            game.TakeField(new Intersection { Row = 1, Column = 1 }, Player.X);

            // Assert
            Assert.AreEqual<int>(1, game.CountOfFieldsPlayed);
        }

        [TestMethod]
        public void FirstPlayerCannotBeO()
        {
            // Act
            game.TakeField(new Intersection { Row = 1, Column = 1 }, Player.O);

            // Assert
            Assert.AreEqual<int>(0, game.CountOfFieldsPlayed);
        }

        [TestMethod]
        public void PlayersMustSwitchOnEachTurn()
        {
            // Act
            game.TakeField(new Intersection { Row = 1, Column = 1 }, Player.X);

            // Assert
            Assert.AreEqual<Player>(Player.O, game.ActivePlayer);
        }

        [TestMethod]
        public void PlayerCannotPlayConsecutively()
        {
            // Act
            WhenPlayerTriesToPlayConsecutively();

            // Assert
            Assert.AreEqual<int>(2, game.CountOfFieldsPlayed);
        }        

        [TestMethod]
        public void PlayerCannotTakeAFieldAlreadyTaken()
        {
            // Act
            WhenPlayerTriesToTakeAFieldAlreadyTaken();

            // Assert
            Assert.AreEqual<int>(1, game.CountOfFieldsPlayed, "One field played");
            Assert.AreEqual<Player>(Player.O, game.ActivePlayer, "Active player is O");
        }           

        [TestMethod]
        public void GameIsOverWhenAllFieldsAreTaken()
        {
            // Act
            WhenAllFieldsAreTaken();

            // Assert
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual(null, game.Winner, "No winner");
        }        

        [TestMethod]
        public void PlayerWinsByRow()
        {
            // Act
            WhenPlayerXWinsGameByRow();

            // Assert
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual<Player?>(Player.X, game.Winner, "Player X is winner");
        }               

        [TestMethod]
        public void FieldsCannotBeTakenWhenGameIsWon()
        {
            // Act
            WhenPlayerXWinsGameByRow();
            game.TakeField(new Intersection { Row = 3, Column = 3 }, Player.O);

            // Assert
            Assert.AreEqual<int>(5, game.CountOfFieldsPlayed);
        }        

        [TestMethod]
        public void PlayerWinsByColumn()
        {
            // Act
            WhenPlayerXWinsGameByColumn();

            // Assert
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual<Player?>(Player.X, game.Winner, "Player X is winner");
        }        

        [TestMethod]
        public void DownDiagonalTakenByPlayerXWinsGame()
        {
            // Act
            WhenPlayerXWinsGameByDownDiagonal();

            // Assert
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual<Player?>(Player.X, game.Winner, "Player X is winner");
        }        

        [TestMethod]
        public void UpDiagonalTakenByPlayerOWinsGame()
        {
            // Act
            WhenPlayerOWinsGameByUpDiagonal();

            // Assert
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual<Player?>(Player.O, game.Winner, "Player O is winner");
        }

        private void WhenPlayerTriesToPlayConsecutively()
        {
            game.TakeField(new Intersection { Row = 2, Column = 1 }, Player.X);
            game.TakeField(new Intersection { Row = 1, Column = 1 }, Player.O);
            game.TakeField(new Intersection { Row = 1, Column = 2 }, Player.O);
        }

        private void WhenPlayerTriesToTakeAFieldAlreadyTaken()
        {
            game.TakeField(new Intersection { Row = 1, Column = 1 }, Player.X);
            game.TakeField(new Intersection { Row = 1, Column = 1 }, Player.O);
        }

        private void WhenAllFieldsAreTaken()
        {
            game.TakeField(new Intersection { Row = 1, Column = 2 }, Player.X);
            game.TakeField(new Intersection { Row = 1, Column = 1 }, Player.O);
            game.TakeField(new Intersection { Row = 2, Column = 2 }, Player.X);
            game.TakeField(new Intersection { Row = 1, Column = 3 }, Player.O);
            game.TakeField(new Intersection { Row = 2, Column = 3 }, Player.X);
            game.TakeField(new Intersection { Row = 2, Column = 1 }, Player.O);
            game.TakeField(new Intersection { Row = 3, Column = 1 }, Player.X);
            game.TakeField(new Intersection { Row = 3, Column = 2 }, Player.O);
            game.TakeField(new Intersection { Row = 3, Column = 3 }, Player.X);
        }

        private void WhenPlayerXWinsGameByRow()
        {
            game.TakeField(new Intersection { Row = 1, Column = 1 }, Player.X);
            game.TakeField(new Intersection { Row = 3, Column = 1 }, Player.O);
            game.TakeField(new Intersection { Row = 1, Column = 2 }, Player.X);
            game.TakeField(new Intersection { Row = 2, Column = 2 }, Player.O);
            game.TakeField(new Intersection { Row = 1, Column = 3 }, Player.X);
        }

        private void WhenPlayerXWinsGameByColumn()
        {
            game.TakeField(new Intersection { Row = 1, Column = 1 }, Player.X);
            game.TakeField(new Intersection { Row = 3, Column = 2 }, Player.O);
            game.TakeField(new Intersection { Row = 2, Column = 1 }, Player.X);
            game.TakeField(new Intersection { Row = 2, Column = 2 }, Player.O);
            game.TakeField(new Intersection { Row = 3, Column = 1 }, Player.X);
        }

        private void WhenPlayerXWinsGameByDownDiagonal()
        {
            game.TakeField(new Intersection { Row = 1, Column = 1 }, Player.X);
            game.TakeField(new Intersection { Row = 1, Column = 2 }, Player.O);
            game.TakeField(new Intersection { Row = 2, Column = 2 }, Player.X);
            game.TakeField(new Intersection { Row = 2, Column = 1 }, Player.O);
            game.TakeField(new Intersection { Row = 3, Column = 3 }, Player.X);
        }

        private void WhenPlayerOWinsGameByUpDiagonal()
        {
            game.TakeField(new Intersection { Row = 3, Column = 2 }, Player.X);
            game.TakeField(new Intersection { Row = 3, Column = 1 }, Player.O);
            game.TakeField(new Intersection { Row = 1, Column = 1 }, Player.X);
            game.TakeField(new Intersection { Row = 2, Column = 2 }, Player.O);
            game.TakeField(new Intersection { Row = 1, Column = 2 }, Player.X);
            game.TakeField(new Intersection { Row = 1, Column = 3 }, Player.O);
        }
    }
}
