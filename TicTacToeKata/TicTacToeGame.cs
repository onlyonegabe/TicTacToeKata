using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        private Field field;
        private List<Field> fieldsPlayed = new List<Field>();
        private Player player = new Player();        

        public Player.PlayerType ActivePlayer { get { return player.Current; } }
        public int CountOfFieldsPlayed { get; private set; }
        public bool IsOver { get; set; }

        public void TakeField(int row, int column, Player.PlayerType playerType)
        {
            field = new Field { Row = row, Column = column };

            if (IsMoveValid() && (player.IsPlayersTurn(playerType)))
            {
                TakeTurn();
            }

            if (fieldsPlayed.Count == 9)
            {
                IsOver = true;
            }
        }

        private void TakeTurn()
        {
            CountOfFieldsPlayed++;
            fieldsPlayed.Add(field);
            player.ChangeTurn();
        }

        private bool HasFieldBeenTaken()
        {
            return fieldsPlayed.Any(x => x.Row == field.Row && x.Column == field.Column);
        }

        private bool IsMoveValid()
        {
            return !(field.Row > 3 || field.Column > 3 || HasFieldBeenTaken());
        }
    }
}