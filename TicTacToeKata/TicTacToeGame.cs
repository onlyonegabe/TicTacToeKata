using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        private Field field;
        private List<Field> fieldsPlayed = new List<Field>();

        public Player ActivePlayer { get; private set; }
        public int CountOfFieldsPlayed { get { return fieldsPlayed.Count; } }
        public bool IsOver { get; private set; }
        public Player? Winner { get; private set; }

        public void TakeField(int row, int column, Player player)
        {
            if (IsOver)
            {
                return;
            }

            field = new Field { Row = row, Column = column, TakenBy = player };

            if ((IsActive(player)) && IsMoveValid())
            {
                TakeTurn();
            }            
        }

        private void TakeTurn()
        {
            fieldsPlayed.Add(field);

            if (IsGameWon())
            {
                IsOver = true;
                Winner = ActivePlayer;
                return;
            }

            if (AreAllFieldsPlayed())
            {
                IsOver = true;
                Winner = null;
                return;
            }

            ChangePlayer();
        }

        private bool AreAllFieldsPlayed()
        {
            return fieldsPlayed.Count == 9;
        }

        private bool IsGameWon()
        {
            if (IsGameWonByRow() || IsGameWonByColumn())
            {
                return true;
            }

            return false;
        }

        private bool IsGameWonByColumn()
        {
            return fieldsPlayed.Where(x => x.TakenBy == ActivePlayer).GroupBy(x => x.Column).Any(x => x.Count() == 3);
        }

        private bool IsGameWonByRow()
        {
            return fieldsPlayed.Where(x => x.TakenBy == ActivePlayer).GroupBy(x => x.Row).Any(x => x.Count() == 3);
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