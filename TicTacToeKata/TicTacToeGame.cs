using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        private List<Field> fieldsPlayed = new List<Field>();
        private Player player = new Player();
        private int row;
        private int column;

        public Player.PlayerType CurrentPlayer { get { return player.Current; } }
        public int CountOfFieldsPlayed { get; private set; }
        public bool IsOver { get; set; }

        public void TakeField(int row, int column, Player.PlayerType playerType)
        {
            (this.row, this.column) = (row, column);

            if (IsMoveValid() && (player.IsPlayersTurn(playerType)))
            {
                TakeTurn(row, column, playerType);
            }

            if (fieldsPlayed.Count == 9)
            {
                IsOver = true;
            }
        }

        private void TakeTurn(int row, int column, Player.PlayerType playerType)
        {
            CountOfFieldsPlayed++;
            fieldsPlayed.Add(new Field { Row = row, Column = column, TakenBy = playerType });
            player.ChangeTurn();
        }

        private bool HasFieldBeenTaken()
        {
            return fieldsPlayed.Any(x => x.Row == row && x.Column == column);
        }

        private bool IsMoveValid()
        {
            return !(row > 3 || column > 3 || HasFieldBeenTaken());
        }
    }
}