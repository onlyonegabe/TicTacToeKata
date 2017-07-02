using System.Collections.Generic;

namespace TicTacToeKata
{
    public class Board
    {
        public int CountOfFieldsPlayed { get { return FieldsPlayed.Count; } }

        public List<Field> FieldsPlayed { get; private set; }

        public Board()
        {
            FieldsPlayed = new List<Field>();
        }

        public void Place(Intersection intersection, Player player)
        {
            FieldsPlayed.Add(new Field { Intersection = intersection, TakenBy = player });
        }
    }
}