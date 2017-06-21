using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToeKata.Tests
{
    [TestClass]
    public class TicTacToeKataTests
    {
        private TicTacToeGame game;

        [TestInitialize]
        public void SetUp()
        {
            game = new TicTacToeGame();
        }

        [TestMethod]
        public void FirstPlayerMustBeX()
        {
            // Act
            game.TakeField(1, 1, Player.X);

            // Assert
            Assert.AreEqual<int>(1, game.CountOfFieldsPlayed);
        }

        [TestMethod]
        public void FirstPlayerCannotBeO()
        {
            // Act
            game.TakeField(1, 1, Player.O);

            // Assert
            Assert.AreEqual<int>(0, game.CountOfFieldsPlayed);
        }

        [TestMethod]
        public void PlayersMustSwitchOnEachTurn()
        {
            // Act
            game.TakeField(1, 1, Player.X);

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
        public void OutOfBounds()
        {
            WhenRowIsTooBig();
            Assert.AreEqual<int>(0, game.CountOfFieldsPlayed);

            WhenColumnIsTooBig();
            Assert.AreEqual<int>(0, game.CountOfFieldsPlayed);

            WhenRowIsTooSmall();
            Assert.AreEqual<int>(0, game.CountOfFieldsPlayed);

            WhenColumnIsTooSmall();
            Assert.AreEqual<int>(0, game.CountOfFieldsPlayed);
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
        public void RowTakenByPlayerXWinsGame()
        {
            // Act
            WhenPlayerXWinsGameByRow();

            // Assert
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual<Player?>(Player.X, game.Winner, "Player X is winner");
        }        

        [TestMethod]
        public void RowTakenByPlayerOWinsGame()
        {
            // Act
            WhenPlayerOWinsGameByRow();

            // Assert
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual<Player?>(Player.O, game.Winner, "Player O is winner");
        }        

        [TestMethod]
        public void FieldsCannotBeTakenWhenGameIsWon()
        {
            // Act
            WhenPlayerXWinsGameByRow();
            game.TakeField(3, 3, Player.O);

            // Assert
            Assert.AreEqual<int>(5, game.CountOfFieldsPlayed);
        }        

        [TestMethod]
        public void ColumnTakenByPlayerXWinsGame()
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

        private void WhenColumnIsTooSmall()
        {
            game.TakeField(1, -1, Player.X);
        }

        private void WhenRowIsTooSmall()
        {
            game.TakeField(-1, 1, Player.X);
        }

        private void WhenColumnIsTooBig()
        {
            game.TakeField(1, 4, Player.X);
        }

        private void WhenRowIsTooBig()
        {
            game.TakeField(4, 1, Player.X);
        }

        private void WhenPlayerTriesToPlayConsecutively()
        {
            game.TakeField(2, 1, Player.X);
            game.TakeField(1, 1, Player.O);
            game.TakeField(1, 2, Player.O);
        }

        private void WhenPlayerTriesToTakeAFieldAlreadyTaken()
        {
            game.TakeField(1, 1, Player.X);
            game.TakeField(1, 1, Player.O);
        }

        private void WhenAllFieldsAreTaken()
        {
            game.TakeField(1, 2, Player.X);
            game.TakeField(1, 1, Player.O);
            game.TakeField(2, 2, Player.X);
            game.TakeField(1, 3, Player.O);
            game.TakeField(2, 3, Player.X);
            game.TakeField(2, 1, Player.O);
            game.TakeField(3, 1, Player.X);
            game.TakeField(3, 2, Player.O);
            game.TakeField(3, 3, Player.X);
        }

        private void WhenPlayerOWinsGameByRow()
        {
            game.TakeField(1, 1, Player.X);
            game.TakeField(2, 1, Player.O);
            game.TakeField(3, 2, Player.X);
            game.TakeField(2, 2, Player.O);
            game.TakeField(1, 3, Player.X);
            game.TakeField(2, 3, Player.O);
        }

        private void WhenPlayerXWinsGameByRow()
        {
            game.TakeField(1, 1, Player.X);
            game.TakeField(3, 1, Player.O);
            game.TakeField(1, 2, Player.X);
            game.TakeField(2, 2, Player.O);
            game.TakeField(1, 3, Player.X);
        }

        private void WhenPlayerXWinsGameByColumn()
        {
            game.TakeField(1, 1, Player.X);
            game.TakeField(3, 2, Player.O);
            game.TakeField(2, 1, Player.X);
            game.TakeField(2, 2, Player.O);
            game.TakeField(3, 1, Player.X);
        }

        private void WhenPlayerXWinsGameByDownDiagonal()
        {
            game.TakeField(1, 1, Player.X);
            game.TakeField(1, 2, Player.O);
            game.TakeField(2, 2, Player.X);
            game.TakeField(2, 1, Player.O);
            game.TakeField(3, 3, Player.X);
        }

        private void WhenPlayerOWinsGameByUpDiagonal()
        {
            game.TakeField(3, 2, Player.X);
            game.TakeField(3, 1, Player.O);
            game.TakeField(1, 1, Player.X);
            game.TakeField(2, 2, Player.O);
            game.TakeField(1, 2, Player.X);
            game.TakeField(1, 3, Player.O);
        }
    }
}
