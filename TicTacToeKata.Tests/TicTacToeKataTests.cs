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
            // Act
            int numberOfFieldsPlayed = game.NumberOfFieldsPlayed;

            // Assert
            Assert.AreEqual<int>(0, numberOfFieldsPlayed);
        }

        private (TicTacToeGame.Player playerX, int rowPlayed, int columnPlayed) GivenFieldPlayedByPlayerX()
        {
            return (TicTacToeGame.Player.X, 1, 1);
        }

        [TestMethod]
        public void NumberOfFieldsPlayedIsOne_WhenFirstFieldIsTaken()
        {
            // Arrange
            (var playerX, var rowPlayed, var columnPlayed) = GivenFieldPlayedByPlayerX();

            // Act
            game.TakeField(rowPlayed, columnPlayed, playerX);

            // Assert
            int numberOfFieldsPlayed = game.NumberOfFieldsPlayed;
            Assert.AreEqual<int>(1, numberOfFieldsPlayed);
        }

        [TestMethod]
        public void CurrentPlayerIsY_WhenPlayerXPlaysAField()
        {
            // Arrange
            (var playerX, var rowPlayed, var columnPlayed) = GivenFieldPlayedByPlayerX();

            // Act
            game.TakeField(rowPlayed, columnPlayed, playerX);

            // Assert
            Assert.AreEqual<TicTacToeGame.Player>(TicTacToeGame.Player.Y, game.CurrentPlayer);
        }
    }
}
