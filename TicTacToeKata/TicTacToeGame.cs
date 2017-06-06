namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        public int NumberOfFieldsPlayed { get; internal set; }

        public enum Player
        {
            X
        };

        public void TakeField(int row, int column, Player player)
        {
            NumberOfFieldsPlayed++;
        }
    }
}