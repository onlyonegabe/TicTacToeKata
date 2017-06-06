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

        [TestMethod]
        public void Player1TakesFirstField()
        {
            // Arrange
            var player1 = TicTacToeGame.Player.X;
            int rowPlayed = 1;
            int columnPlayed = 1;

            // Act
            game.TakeField(rowPlayed, columnPlayed, player1);

            // Assert
            int numberOfFieldsPlayed = game.NumberOfFieldsPlayed;
            Assert.AreEqual<int>(1, numberOfFieldsPlayed);
        }
    }
}
