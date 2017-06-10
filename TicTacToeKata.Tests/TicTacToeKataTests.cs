﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        private void WhenPlayerTriesToPlayConsecutively()
        {
            game.TakeField(2, 1, Player.X);
            game.TakeField(1, 1, Player.O);
            game.TakeField(1, 2, Player.O);
        }

        [TestMethod]
        public void PlayerCannotTakeAFieldAlreadyTaken()
        {
            // Act
            WhenPlayerTriesToTakeAFieldAlreadyTaken();

            // Assert
            Assert.AreEqual<int>(1, game.CountOfFieldsPlayed);
            Assert.AreEqual<Player>(Player.O, game.ActivePlayer);
        }

        private void WhenPlayerTriesToTakeAFieldAlreadyTaken()
        {
            game.TakeField(1, 1, Player.X);
            game.TakeField(1, 1, Player.O);
        }

        [TestMethod]
        public void RowCannotBeGreaterThan3()
        {
            // Act
            game.TakeField(4, 1, Player.X);

            // Assert
            Assert.AreEqual<int>(0, game.CountOfFieldsPlayed);
        }

        [TestMethod]
        public void ColumnCannotBeGreaterThan3()
        {
            // Act
            game.TakeField(1, 4, Player.X);

            // Assert
            Assert.AreEqual<int>(0, game.CountOfFieldsPlayed);
        }

        [TestMethod]
        public void GameIsOverWhenAllFieldsAreTaken()
        {
            // Act
            WhenAllFieldsAreTaken();

            // Assert
            Assert.AreEqual<bool>(true, game.IsOver);
        }

        private void WhenAllFieldsAreTaken()
        {
            game.TakeField(1, 1, Player.X);
            game.TakeField(1, 2, Player.O);
            game.TakeField(1, 3, Player.X);
            game.TakeField(2, 1, Player.O);
            game.TakeField(2, 2, Player.X);
            game.TakeField(2, 3, Player.O);
            game.TakeField(3, 1, Player.X);
            game.TakeField(3, 2, Player.O);
            game.TakeField(3, 3, Player.X);
        }
    }
}
