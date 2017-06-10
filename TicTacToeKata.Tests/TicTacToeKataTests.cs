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
        public void FirstIsPlayerIsX()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (1, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, PlayerType.X);

            // Assert
            Assert.AreEqual<int>(1, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void FirstPlayerCannotBeO()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (1, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, PlayerType.O);

            // Assert
            Assert.AreEqual<int>(0, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void CurrentPlayerBecomesTheOtherPlayer_WhenFieldIsTaken()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (1, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, PlayerType.X);

            // Assert
            Assert.AreEqual<PlayerType>(PlayerType.O, game.CurrentPlayer);
        }

        [TestMethod]
        public void PlayerCannotTakeFieldsConsecutively()
        {
            // Arrange
            (int rowPlayedByX, int columnPlayedByX) = (2, 1);
            (int rowPlayedByO, int firstColumnPlayedByO, int secondColumnPlayedByO) = (1, 1, 2);

            // Act
            game.TakeField(rowPlayedByX, columnPlayedByX, PlayerType.X);
            game.TakeField(rowPlayedByO, firstColumnPlayedByO, PlayerType.O);
            game.TakeField(rowPlayedByO, secondColumnPlayedByO, PlayerType.O);

            // Assert
            Assert.AreEqual<int>(2, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void PlayerCannotTakeAFieldAlreadyTaken()
        {
            // Arrange
            (int rowPlayedByX, int columnPlayedByX) = (1, 1);
            (int rowPlayedByO, int columnPlayedByO) = (1, 1);

            // Act
            game.TakeField(rowPlayedByX, columnPlayedByX, PlayerType.X);
            game.TakeField(rowPlayedByO, columnPlayedByO, PlayerType.O);

            // Assert
            Assert.AreEqual<int>(1, game.NumberOfFieldsPlayed);
            Assert.AreEqual<PlayerType>(PlayerType.O, game.CurrentPlayer);
        }

        [TestMethod]
        public void FieldRowCannotBeGreaterThan3()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (4, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, PlayerType.X);

            // Assert
            Assert.AreEqual<int>(0, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void ColumnCannotBeGreaterThan3()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (1, 4);

            // Act
            game.TakeField(rowPlayed, columnPlayed, PlayerType.X);

            // Assert
            Assert.AreEqual<int>(0, game.NumberOfFieldsPlayed);
        }
    }
}
