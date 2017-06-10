using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        private List<Field> fieldsPlayed = new List<Field>();

        public int NumberOfFieldsPlayed { get; internal set; }
        public Player CurrentPlayer { get; internal set; }

        private bool HasFieldBeenTaken(int row, int column)
        {
            return fieldsPlayed.Any(x => x.Row == row && x.Column == column);
        }

        private void ChangePlayersTurn()
        {
            if (CurrentPlayer == Player.X)
            {
                CurrentPlayer = Player.O;
            }
            else if (CurrentPlayer == Player.O)
            {
                CurrentPlayer = Player.X;
            }
        }

        public void TakeField(int row, int column, Player player)
        {
            if (IsMoveValid(row, column) && (IsPlayersTurn(player)))
            {
                NumberOfFieldsPlayed++;
                fieldsPlayed.Add(new Field { Row = row, Column = column, TakenBy = player });
                ChangePlayersTurn();
            }
        }

        private bool IsPlayersTurn(Player player)
        {
            return CurrentPlayer == player;
        }

        private bool IsMoveValid(int row, int column)
        {
            return !(row > 3 || HasFieldBeenTaken(row, column));
        }
    }
}