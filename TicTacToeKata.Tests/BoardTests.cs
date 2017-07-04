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
        public void WhenInvalidIntersection_WillNotPlace()
        {
            board.Place(new Intersection { Row = 4, Column = 1 }, Player.X);
            Assert.AreEqual<int>(0, board.NumberOfFieldsPlayed);

            board.Place(new Intersection { Row = 1, Column = 4 }, Player.X);
            Assert.AreEqual<int>(0, board.NumberOfFieldsPlayed);

            board.Place(new Intersection { Row = -1, Column = 3 }, Player.X);
            Assert.AreEqual<int>(0, board.NumberOfFieldsPlayed);

            board.Place(new Intersection { Row = 1, Column = -1 }, Player.X);
            Assert.AreEqual<int>(0, board.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void WhenIntersectionAlreadyTaken_WillNotPlace()
        {
            board.Place(new Intersection { Row = 3, Column = 3 }, Player.X);
            board.Place(new Intersection { Row = 3, Column = 3 }, Player.O);
            Assert.AreEqual<int>(1, board.NumberOfFieldsPlayed);
        }

        [TestMethod]
        public void GivenWidthAndHeight_AllFieldsArePlayed()
        {
            Assert.IsFalse(board.IsBoardFull(), "Empty board");

            FillBoard(3, 3);
            Assert.IsTrue(board.IsBoardFull(), "Board 3x3");

            FillBoard(4, 4);
            Assert.IsTrue(board.IsBoardFull(), "Board 4x4");
        }

        private void FillBoard(int row, int column)
        {
            board = new Board(row, column);
            for (int x = 1; x <= row; x++)
            {
                for (int y = 1; y <= column; y++)
                {
                    board.Place(new Intersection { Row = x, Column = y }, Player.X);
                }
            }
        }
    }
}
