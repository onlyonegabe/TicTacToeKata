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
            game.TakeField(1, 1, Player.PlayerType.X);

            // Assert
            Assert.AreEqual<int>(1, game.CountOfFieldsPlayed);
        }

        [TestMethod]
        public void FirstPlayerCannotBeO()
        {
            // Act
            game.TakeField(1, 1, Player.PlayerType.O);

            // Assert
            Assert.AreEqual<int>(0, game.CountOfFieldsPlayed);
        }

        [TestMethod]
        public void PlayersMustSwitchOnEachTurn()
        {
            // Act
            game.TakeField(1, 1, Player.PlayerType.X);

            // Assert
            Assert.AreEqual<Player.PlayerType>(Player.PlayerType.O, game.CurrentPlayer);
        }

        [TestMethod]
        public void PlayerCannotPlayConsecutively()
        {
            // Act
            GivenThatPlayerTriesToPlayConsecutively();

            // Assert
            Assert.AreEqual<int>(2, game.CountOfFieldsPlayed);
        }

        private void GivenThatPlayerTriesToPlayConsecutively()
        {
            game.TakeField(2, 1, Player.PlayerType.X);
            game.TakeField(1, 1, Player.PlayerType.O);
            game.TakeField(1, 2, Player.PlayerType.O);
        }

        [TestMethod]
        public void PlayerCannotTakeAFieldAlreadyTaken()
        {
            // Act
            GivenThatPlayerTriesToTakeAFieldAlreadyTaken();

            // Assert
            Assert.AreEqual<int>(1, game.CountOfFieldsPlayed);
            Assert.AreEqual<Player.PlayerType>(Player.PlayerType.O, game.CurrentPlayer);
        }

        private void GivenThatPlayerTriesToTakeAFieldAlreadyTaken()
        {
            game.TakeField(1, 1, Player.PlayerType.X);
            game.TakeField(1, 1, Player.PlayerType.O);
        }

        [TestMethod]
        public void RowCannotBeGreaterThan3()
        {
            // Act
            game.TakeField(4, 1, Player.PlayerType.X);

            // Assert
            Assert.AreEqual<int>(0, game.CountOfFieldsPlayed);
        }

        [TestMethod]
        public void ColumnCannotBeGreaterThan3()
        {
            // Act
            game.TakeField(1, 4, Player.PlayerType.X);

            // Assert
            Assert.AreEqual<int>(0, game.CountOfFieldsPlayed);
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
