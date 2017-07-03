using System.Linq;

namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        private IBoard board;

        public Player ActivePlayer { get; private set; }
        public int CountOfFieldsPlayed { get { return board.CountOfFieldsPlayed; } }
        public bool IsOver { get; private set; }
        public Player? Winner { get; private set; }

        public TicTacToeGame(IBoard board)
        {
            this.board = board; 
        }

        public void TakeField(Intersection intersection, Player player)
        {
            if (IsOver)
            {
                return;
            }

            if (IsActive(player))
            {
                TakeTurn(intersection, player);
            }            
        }
        
        private void TakeTurn(Intersection intersection, Player player)
        {
            int countOfFieldsPlayed = board.CountOfFieldsPlayed;
            board.Place(intersection, player);

            if (IsGameWon())
            {
                IsOver = true;
                Winner = ActivePlayer;
                return;
            }

            if (board.AreAllFieldsPlayed())
            {
                IsOver = true;
                Winner = null;
                return;
            }

            if (board.CountOfFieldsPlayed == countOfFieldsPlayed + 1)
            {
                ChangePlayer();
            }
        }

        private bool IsGameWon()
        {
            if (IsWonByRow() || IsWonByColumn() || IsWonByDiagonal())
            {
                return true;
            }

            return false;
        }

        private bool IsWonByDiagonal()
        {
            return IsWonByDownDiagonal() || IsWonByUpDiagonal();
        }

        private bool IsWonByUpDiagonal()
        {
            return board.FieldsPlayed.Where(x => x.TakenBy == ActivePlayer && x.Intersection.Row == 3 && x.Intersection.Column == 1).Any()
                && board.FieldsPlayed.Where(x => x.TakenBy == ActivePlayer && x.Intersection.Row == 2 && x.Intersection.Column == 2).Any()
                && board.FieldsPlayed.Where(x => x.TakenBy == ActivePlayer && x.Intersection.Row == 1 && x.Intersection.Column == 3).Any();
        }

        private bool IsWonByDownDiagonal()
        {
            return board.FieldsPlayed.Where(x => x.TakenBy == ActivePlayer && x.Intersection.Row == 1  && x.Intersection.Column == 1).Any()
                && board.FieldsPlayed.Where(x => x.TakenBy == ActivePlayer && x.Intersection.Row == 2 && x.Intersection.Column == 2).Any()
                && board.FieldsPlayed.Where(x => x.TakenBy == ActivePlayer && x.Intersection.Row == 3 && x.Intersection.Column == 3).Any();
        }

        private bool IsWonByColumn()
        {
            return board.FieldsPlayed.Where(x => x.TakenBy == ActivePlayer).GroupBy(x => x.Intersection.Column).Any(x => x.Count() == 3);
        }

        private bool IsWonByRow()
        {
            return board.FieldsPlayed.Where(x => x.TakenBy == ActivePlayer).GroupBy(x => x.Intersection.Row).Any(x => x.Count() == 3);
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
    }
}