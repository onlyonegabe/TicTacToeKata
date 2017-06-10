namespace TicTacToeKata
{
    public class Player
    {
        public enum PlayerType { X, O };
        
        public PlayerType Change(PlayerType playerType)
        {
            if (playerType == PlayerType.X)
            {
                return PlayerType.O;
            }

            return PlayerType.X;
        }
    }
}
