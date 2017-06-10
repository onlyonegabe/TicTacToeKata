using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        private Field field;
        private List<Field> fieldsPlayed = new List<Field>();
        private Player player = new Player();        

        public Player.PlayerType ActivePlayer { get; private set;  } 
        public int CountOfFieldsPlayed { get; private set; }
        public bool IsOver { get; set; }

        public void TakeField(int row, int column, Player.PlayerType playerType)
        {
            field = new Field { Row = row, Column = column };

            if (IsMoveValid() && (IsActive(playerType)))
            {
                TakeTurn();
            }

            if (fieldsPlayed.Count == 9)
            {
                IsOver = true;
            }
        }

        private bool IsActive(Player.PlayerType playerType)
        {
            return playerType == ActivePlayer;
        }

        private void TakeTurn()
        {
            CountOfFieldsPlayed++;
            fieldsPlayed.Add(field);
            ActivePlayer = player.Change(ActivePlayer);
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