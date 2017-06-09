namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        public int NumberOfFieldsPlayed { get; internal set; }

        public Player CurrentPlayer { get; internal set; }

        public enum Player
        {
            X,
            O
        };

        public void TakeField(int row, int column, Player player)
        {
            if (CurrentPlayer == player)
            {
                NumberOfFieldsPlayed++;
                ChangePlayer();
            }
        }

        private void ChangePlayer()
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
    }
}