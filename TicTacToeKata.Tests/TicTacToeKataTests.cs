using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToeKata.Tests
{
    [TestClass]
    public class TicTacToeKataTests
    {
        private TicTacToeGame game;
        private Board board = new Board(3, 3);

        [TestInitialize]
        public void SetUp()
        {
            game = new TicTacToeGame(board);
        }

        [TestMethod]
        public void FirstPlayerMustBeX()
        {
            game.Play(new Intersection { Row = 1, Column = 1 }, Player.X);
            Assert.AreEqual<int>(1, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void FirstPlayerCannotBeO()
        {
            game.Play(new Intersection { Row = 1, Column = 1 }, Player.O);
            Assert.AreEqual<int>(0, game.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void PlayersMustSwitchOnEachTurn()
        {
            game.Play(new Intersection { Row = 1, Column = 1 }, Player.X);
            Assert.AreEqual<Player>(Player.O, game.ActivePlayer);
        }

        [TestMethod]
        public void PlayerCannotPlayConsecutively()
        {
            WhenPlayerTriesToPlayConsecutively();
            Assert.AreEqual<int>(2, game.NumberOfFieldsPlayed);
        }        

        [TestMethod]
        public void GameIsOverWhenAllFieldsAreTaken()
        {
            WhenAllFieldsAreTaken();
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual(null, game.Winner, "No winner");
        }        

        [TestMethod]
        public void PlayerWinsByRow()
        {
            WhenPlayerXWinsGameByRow();
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual<Player?>(Player.X, game.Winner, "Player X is winner");
        }               

        [TestMethod]
        public void FieldsCannotBeTakenWhenGameIsWon()
        {
            WhenPlayerXWinsGameByRow();
            game.Play(new Intersection { Row = 3, Column = 3 }, Player.O);
            Assert.AreEqual<int>(5, game.NumberOfFieldsPlayed);
        }        

        [TestMethod]
        public void PlayerWinsByColumn()
        {
            WhenPlayerXWinsGameByColumn();
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual<Player?>(Player.X, game.Winner, "Player X is winner");
        }        

        [TestMethod]
        public void DownDiagonalTakenByPlayerXWinsGame()
        {
            WhenPlayerXWinsGameByDownDiagonal();
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual<Player?>(Player.X, game.Winner, "Player X is winner");
        }        

        [TestMethod]
        public void UpDiagonalTakenByPlayerOWinsGame()
        {
            WhenPlayerOWinsGameByUpDiagonal();
            Assert.AreEqual<bool>(true, game.IsOver, "Game is over");
            Assert.AreEqual<Player?>(Player.O, game.Winner, "Player O is winner");
        }

        [TestMethod]
        public void PlayerWinsOnFullBoard()
        {
            WhenPlayerWinsOnFullBoard();
            Assert.AreEqual<Player?>(Player.X, game.Winner);
        }

        private void WhenPlayerWinsOnFullBoard()
        {
            game.Play(new Intersection { Row = 1, Column = 2 }, Player.X);
            game.Play(new Intersection { Row = 1, Column = 1 }, Player.O);
            game.Play(new Intersection { Row = 2, Column = 2 }, Player.X);
            game.Play(new Intersection { Row = 1, Column = 3 }, Player.O);
            game.Play(new Intersection { Row = 2, Column = 3 }, Player.X);
            game.Play(new Intersection { Row = 2, Column = 1 }, Player.O);
            game.Play(new Intersection { Row = 3, Column = 1 }, Player.X);
            game.Play(new Intersection { Row = 3, Column = 3 }, Player.O);
            game.Play(new Intersection { Row = 3, Column = 2 }, Player.X);
        }

        private void WhenPlayerTriesToPlayConsecutively()
        {
            game.Play(new Intersection { Row = 2, Column = 1 }, Player.X);
            game.Play(new Intersection { Row = 1, Column = 1 }, Player.O);
            game.Play(new Intersection { Row = 1, Column = 2 }, Player.O);
        }

        private void WhenAllFieldsAreTaken()
        {
            game.Play(new Intersection { Row = 1, Column = 2 }, Player.X);
            game.Play(new Intersection { Row = 1, Column = 1 }, Player.O);
            game.Play(new Intersection { Row = 2, Column = 2 }, Player.X);
            game.Play(new Intersection { Row = 1, Column = 3 }, Player.O);
            game.Play(new Intersection { Row = 2, Column = 3 }, Player.X);
            game.Play(new Intersection { Row = 2, Column = 1 }, Player.O);
            game.Play(new Intersection { Row = 3, Column = 1 }, Player.X);
            game.Play(new Intersection { Row = 3, Column = 2 }, Player.O);
            game.Play(new Intersection { Row = 3, Column = 3 }, Player.X);
        }

        private void WhenPlayerXWinsGameByRow()
        {
            game.Play(new Intersection { Row = 1, Column = 1 }, Player.X);
            game.Play(new Intersection { Row = 3, Column = 1 }, Player.O);
            game.Play(new Intersection { Row = 1, Column = 2 }, Player.X);
            game.Play(new Intersection { Row = 2, Column = 2 }, Player.O);
            game.Play(new Intersection { Row = 1, Column = 3 }, Player.X);
        }

        private void WhenPlayerXWinsGameByColumn()
        {
            game.Play(new Intersection { Row = 1, Column = 1 }, Player.X);
            game.Play(new Intersection { Row = 3, Column = 2 }, Player.O);
            game.Play(new Intersection { Row = 2, Column = 1 }, Player.X);
            game.Play(new Intersection { Row = 2, Column = 2 }, Player.O);
            game.Play(new Intersection { Row = 3, Column = 1 }, Player.X);
        }

        private void WhenPlayerXWinsGameByDownDiagonal()
        {
            game.Play(new Intersection { Row = 1, Column = 1 }, Player.X);
            game.Play(new Intersection { Row = 1, Column = 2 }, Player.O);
            game.Play(new Intersection { Row = 2, Column = 2 }, Player.X);
            game.Play(new Intersection { Row = 2, Column = 1 }, Player.O);
            game.Play(new Intersection { Row = 3, Column = 3 }, Player.X);
        }

        private void WhenPlayerOWinsGameByUpDiagonal()
        {
            game.Play(new Intersection { Row = 3, Column = 2 }, Player.X);
            game.Play(new Intersection { Row = 3, Column = 1 }, Player.O);
            game.Play(new Intersection { Row = 1, Column = 1 }, Player.X);
            game.Play(new Intersection { Row = 2, Column = 2 }, Player.O);
            game.Play(new Intersection { Row = 1, Column = 2 }, Player.X);
            game.Play(new Intersection { Row = 1, Column = 3 }, Player.O);
        }
    }
}
