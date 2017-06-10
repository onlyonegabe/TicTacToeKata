namespace TicTacToeKata
{
    public class Player
    {
        public PlayerType Current;

        public void ChangeTurn()
        {
            if (Current == PlayerType.X)
            {
                Current = PlayerType.O;
            }
            else if (Current == PlayerType.O)
            {
                Current = PlayerType.X;
            }
        }

        public bool IsPlayersTurn(PlayerType player)
        {
            return Current == player;
        }
    }
}
