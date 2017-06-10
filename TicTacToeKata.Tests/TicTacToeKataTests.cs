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
            game.TakeField(rowPlayed, columnPlayed, Player.PlayerType.X);

            // Assert
            Assert.AreEqual<int>(1, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void FirstPlayerCannotBeO()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (1, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, Player.PlayerType.O);

            // Assert
            Assert.AreEqual<int>(0, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void CurrentPlayerBecomesTheOtherPlayer_WhenFieldIsTaken()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (1, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, Player.PlayerType.X);

            // Assert
            Assert.AreEqual<Player.PlayerType>(Player.PlayerType.O, game.CurrentPlayer);
        }

        [TestMethod]
        public void PlayerCannotTakeFieldsConsecutively()
        {
            // Arrange
            (int rowPlayedByX, int columnPlayedByX) = (2, 1);
            (int rowPlayedByO, int firstColumnPlayedByO, int secondColumnPlayedByO) = (1, 1, 2);

            // Act
            game.TakeField(rowPlayedByX, columnPlayedByX, Player.PlayerType.X);
            game.TakeField(rowPlayedByO, firstColumnPlayedByO, Player.PlayerType.O);
            game.TakeField(rowPlayedByO, secondColumnPlayedByO, Player.PlayerType.O);

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
            game.TakeField(rowPlayedByX, columnPlayedByX, Player.PlayerType.X);
            game.TakeField(rowPlayedByO, columnPlayedByO, Player.PlayerType.O);

            // Assert
            Assert.AreEqual<int>(1, game.NumberOfFieldsPlayed);
            Assert.AreEqual<Player.PlayerType>(Player.PlayerType.O, game.CurrentPlayer);
        }

        [TestMethod]
        public void FieldRowCannotBeGreaterThan3()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (4, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, Player.PlayerType.X);

            // Assert
            Assert.AreEqual<int>(0, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void ColumnCannotBeGreaterThan3()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (1, 4);

            // Act
            game.TakeField(rowPlayed, columnPlayed, Player.PlayerType.X);

            // Assert
            Assert.AreEqual<int>(0, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void GameIsOverWhenAllFieldsAreTaken()
        {
            // Act
            GivenThatAllFieldsAreTaken();

            // Assert
            Assert.AreEqual<bool>(true, game.IsOver);
        }

        private void GivenThatAllFieldsAreTaken()
        {
            game.TakeField(1, 1, Player.PlayerType.X);
            game.TakeField(1, 2, Player.PlayerType.O);
            game.TakeField(1, 3, Player.PlayerType.X);
            game.TakeField(2, 1, Player.PlayerType.O);
            game.TakeField(2, 2, Player.PlayerType.X);
            game.TakeField(2, 3, Player.PlayerType.O);
            game.TakeField(3, 1, Player.PlayerType.X);
            game.TakeField(3, 2, Player.PlayerType.O);
            game.TakeField(3, 3, Player.PlayerType.X);
        }
    }
}
