namespace TicTacToeKata
{
    public class Field
    {
        //public int Row { get; set; }
        //public int Column { get; set; }
        public Intersection Intersection { get; set; }
        public Player TakenBy { get; set; }
    }
}