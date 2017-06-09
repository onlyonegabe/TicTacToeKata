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
            (int rowPlayed, int columnPlayed) = (1, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, TicTacToeGame.Player.X);

            // Assert
            Assert.AreEqual<int>(1, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void CurrentPlayerBecomesO_WhenPlayerXPlaysAField()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (1, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, TicTacToeGame.Player.X);

            // Assert
            Assert.AreEqual<TicTacToeGame.Player>(TicTacToeGame.Player.O, game.CurrentPlayer);
        }

        [TestMethod]
        public void CurrentPlayerBecomesX_WhenPlayerOPlaysAField()
        {
            // Arrange
            (int rowPlayedByX, int columnPlayedByX) = (1, 1);
            (int rowPlayedByO, int columnPlayedByO) = (1, 2);

            // Act
            game.TakeField(rowPlayedByX, columnPlayedByX, TicTacToeGame.Player.X);
            game.TakeField(rowPlayedByO, columnPlayedByO, TicTacToeGame.Player.O);

            // Assert
            Assert.AreEqual<TicTacToeGame.Player>(TicTacToeGame.Player.X, game.CurrentPlayer);
        }

        [TestMethod]
        public void PlayerXCannotTakeFieldConsecutively()
        {
            // Arrange
            (int rowPlayedByX, int firstColumnPlayedByX, int secondColumnPlayedByX) = (1, 1, 2);

            // Act
            game.TakeField(rowPlayedByX, firstColumnPlayedByX, TicTacToeGame.Player.X);
            game.TakeField(rowPlayedByX, secondColumnPlayedByX, TicTacToeGame.Player.X);

            // Assert
            Assert.AreEqual<int>(1, game.NumberOfFieldsPlayed);
        }
    }
}
