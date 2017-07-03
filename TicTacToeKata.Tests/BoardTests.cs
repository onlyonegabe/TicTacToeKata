using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToeKata.Tests
{
    [TestClass]
    public class BoardTests
    {
        private Board board;

        [TestInitialize]
        public void SetUp()
        {
            board = new Board(3, 3);
        }

        [TestMethod]
        public void CanCreateBoard()
        {
            Assert.IsInstanceOfType(board, typeof(Board));
        }

        [TestMethod]
        public void GivenInvalidIntersectionWillNotPlace()
        {
            board.Place(new Intersection { Row = 4, Column = 1 }, Player.X);
            Assert.AreEqual<int>(0, board.CountOfFieldsPlayed);

            board.Place(new Intersection { Row = 1, Column = 4 }, Player.X);
            Assert.AreEqual<int>(0, board.CountOfFieldsPlayed);

            board.Place(new Intersection { Row = -1, Column = 3 }, Player.X);
            Assert.AreEqual<int>(0, board.CountOfFieldsPlayed);

            board.Place(new Intersection { Row = 1, Column = -1 }, Player.X);
            Assert.AreEqual<int>(0, board.CountOfFieldsPlayed);
        }
    }
}
