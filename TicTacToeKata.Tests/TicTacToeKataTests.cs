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
            game.TakeField(rowPlayed, columnPlayed, TicTacToeGame.Player.X);

            // Assert
            Assert.AreEqual<int>(1, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void FirstPlayerCannotBeO()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (1, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, TicTacToeGame.Player.O);

            // Assert
            Assert.AreEqual<int>(0, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void CurrentPlayerBecomesTheOtherPlayer_WhenFieldIsTaken()
        {
            // Arrange
            (int rowPlayed, int columnPlayed) = (1, 1);

            // Act
            game.TakeField(rowPlayed, columnPlayed, TicTacToeGame.Player.X);

            // Assert
            Assert.AreEqual<TicTacToeGame.Player>(TicTacToeGame.Player.O, game.CurrentPlayer);
        }

        [TestMethod]
        public void PlayerCannotTakeFieldsConsecutively()
        {
            // Arrange
            (int rowPlayedByX, int columnPlayedByX) = (2, 1);
            (int rowPlayedByO, int firstColumnPlayedByO, int secondColumnPlayedByO) = (1, 1, 2);

            // Act
            game.TakeField(rowPlayedByX, columnPlayedByX, TicTacToeGame.Player.X);
            game.TakeField(rowPlayedByO, firstColumnPlayedByO, TicTacToeGame.Player.O);
            game.TakeField(rowPlayedByO, secondColumnPlayedByO, TicTacToeGame.Player.O);

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
            game.TakeField(rowPlayedByX, columnPlayedByX, TicTacToeGame.Player.X);
            game.TakeField(rowPlayedByO, columnPlayedByO, TicTacToeGame.Player.O);

            // Assert
            Assert.AreEqual<int>(1, game.NumberOfFieldsPlayed);
            Assert.AreEqual<TicTacToeGame.Player>(TicTacToeGame.Player.O, game.CurrentPlayer);
        }
    }
}
