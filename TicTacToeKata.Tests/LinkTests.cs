using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata.Tests
{
    [TestClass]
    [Ignore]
    public class LinkTests
    {
        private List<Field> fieldList;

        [TestInitialize]
        public void SetUp()
        {
            fieldList = new List<Field>
            {
                new Field { Row = 2, Column = 1, TakenBy = Player.X },
                new Field { Row = 3, Column = 1, TakenBy = Player.O },
                new Field { Row = 2, Column = 2, TakenBy = Player.X },
                new Field { Row = 3, Column = 2, TakenBy = Player.O },
                new Field { Row = 1, Column = 3, TakenBy = Player.X },
                new Field { Row = 3, Column = 3, TakenBy = Player.O }
            };
        }

        [TestMethod]
        public void Any()
        {
            var results = fieldList.Any(x => x.TakenBy == Player.X);

            Assert.AreEqual<bool>(true, results);
        }

        [TestMethod]
        public void GroupBy()
        {
            var results = fieldList.GroupBy(x => x.TakenBy);

            Assert.AreEqual<int>(2, results.Count());
        }

        [TestMethod]
        public void GetAListOfJustPlayerX()
        {
            List<Field> results = fieldList.Where(x => x.TakenBy == Player.X).ToList();

            Assert.AreEqual<int>(3, results.Count());
            Assert.AreEqual<Player>(Player.X, results[0].TakenBy);
            Assert.AreEqual<Player>(Player.X, results[1].TakenBy);
            Assert.AreEqual<Player>(Player.X, results[2].TakenBy);
        }

        [TestMethod]
        public void FindTheThirdRowWonByPlayerO()
        {
            fieldList = new List<Field>
            {
                new Field { Row = 2, Column = 1, TakenBy = Player.X },
                new Field { Row = 3, Column = 1, TakenBy = Player.O },
                new Field { Row = 2, Column = 2, TakenBy = Player.X },
                new Field { Row = 3, Column = 2, TakenBy = Player.O },
                new Field { Row = 1, Column = 3, TakenBy = Player.X },
                new Field { Row = 3, Column = 3, TakenBy = Player.O }
            };

            var results = fieldList.GroupBy(x => x.Row == 3 && x.TakenBy == Player.O).ToList();
            Assert.AreEqual<int>(3, results[0].Count());
        }

        [TestMethod]
        public void FindAnyRowWonByPlayerO()
        {
            fieldList = new List<Field>
            {
                new Field { Row = 2, Column = 1, TakenBy = Player.X },
                new Field { Row = 3, Column = 1, TakenBy = Player.O },
                new Field { Row = 2, Column = 2, TakenBy = Player.X },
                new Field { Row = 3, Column = 2, TakenBy = Player.O },
                new Field { Row = 1, Column = 3, TakenBy = Player.X },
                new Field { Row = 3, Column = 3, TakenBy = Player.O }
            };

            var results = fieldList.Where(x => x.TakenBy == Player.O).GroupBy(x => x.Row);
            Assert.AreEqual<bool>(true, results.Any(x => x.Count() == 3));
        }
    }
}