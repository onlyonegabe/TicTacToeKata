namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        public int NumberOfFieldsPlayed { get; internal set; }

        public Player CurrentPlayer { get; internal set; }

        public enum Player
        {
            X,
            Y
        };

        public void TakeField(int row, int column, Player player)
        {
            NumberOfFieldsPlayed++;
            
            if (CurrentPlayer == Player.X)
            {
                CurrentPlayer = Player.Y;
            }
        }
    }
}