using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        private Field field;
        private List<Field> fieldsPlayed = new List<Field>();

        public Player ActivePlayer { get; private set;  } 
        public int CountOfFieldsPlayed { get { return fieldsPlayed.Count; } }
        public bool IsOver { get; private set; }

        public void TakeField(int row, int column, Player player)
        {
            field = new Field { Row = row, Column = column };

            if (IsMoveValid() && (IsActive(player)))
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
            fieldsPlayed.Add(field);
            ChangePlayer();
        }

        private void ChangePlayer()
        {
            if (ActivePlayer == Player.X)
            {
                ActivePlayer = Player.O;
            }
            else
            {
                ActivePlayer = Player.X;
            }
        }        

        private bool IsActive(Player player)
        {
            return player == ActivePlayer;
        }

        private bool IsMoveValid()
        {
            return !(field.Row > 3 || field.Column > 3 || HasFieldBeenTaken());
        }

        private bool HasFieldBeenTaken()
        {
            return fieldsPlayed.Any(x => x.Row == field.Row && x.Column == field.Column);
        }
    }
}