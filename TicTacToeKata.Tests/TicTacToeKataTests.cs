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
        public void NewGameHasNoFieldsPlayed()
        {
            // Assert
            Assert.AreEqual<int>(0, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void NumberOfFieldsPlayedIsOne_WhenFirstFieldIsTaken()
        {
            // Arrange
            (var playerX, int rowPlayed, int columnPlayed) = (TicTacToeGame.Player.X, 1, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, playerX);

            // Assert
            Assert.AreEqual<int>(1, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void CurrentPlayerBecomesO_WhenPlayerXPlaysAField()
        {
            // Arrange
            (var playerX, int rowPlayed, int columnPlayed) = (TicTacToeGame.Player.X, 1, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, playerX);

            // Assert
            Assert.AreEqual<TicTacToeGame.Player>(TicTacToeGame.Player.O, game.CurrentPlayer);
        }

        [TestMethod]
        public void CurrentPlayerBecomesX_WhenPlayerOPlaysAField()
        {
            // Arrange
            (var playerX, int rowPlayedByX, int columnPlayedByX) = (TicTacToeGame.Player.X, 1, 1);
            (var playerO, int rowPlayedByO, int columnPlayedByO) = (TicTacToeGame.Player.O, 1, 2);

            // Act
            game.TakeField(rowPlayedByX, columnPlayedByX, playerX);
            game.TakeField(rowPlayedByO, columnPlayedByO, playerO);

            // Assert
            Assert.AreEqual<TicTacToeGame.Player>(TicTacToeGame.Player.X, game.CurrentPlayer);
        }
    }
}
