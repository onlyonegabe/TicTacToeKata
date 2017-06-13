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
        public Player Winner { get; private set; }

        public void TakeField(int row, int column, Player player)
        {
            field = new Field { Row = row, Column = column, TakenBy = player };

            if (IsMoveValid() && (IsActive(player)))
            {
                TakeTurn();
            }

            if (fieldsPlayed.Count == 9)
            {
                IsOver = true;
            }

            DetermineWinnerByRow(Player.X);
            DetermineWinnerByRow(Player.O);
        }

        private void DetermineWinnerByRow(Player player)
        {
            int rowOneCount = 0;
            int rowTwoCount = 0;
            int rowThreeCount = 0;
            foreach (var field in fieldsPlayed)
            {
                if (field.Row == 1 && field.TakenBy == player)
                {
                    rowOneCount++;
                }
                if (field.Row == 2 && field.TakenBy == player)
                {
                    rowTwoCount++;
                }
                if (field.Row == 3 && field.TakenBy == player)
                {
                    rowThreeCount++;
                }
            }

            if (rowOneCount == 3 || rowTwoCount == 3 || rowThreeCount == 3)
            {
                IsOver = true;
                Winner = player;
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