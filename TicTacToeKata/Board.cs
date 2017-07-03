using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class Board : IBoard
    {
        private Field field;

        public int CountOfFieldsPlayed { get { return FieldsPlayed.Count; } }
        public List<Field> FieldsPlayed { get; private set; }

        public Board()
        {
            FieldsPlayed = new List<Field>();
        }

        public void Place(Intersection intersection, Player player)
        {
            field = new Field { Intersection = intersection, TakenBy = player };
            if (IsMoveValid())
            {
                FieldsPlayed.Add(field);
            }
        }

        private bool IsMoveValid()
        {
            return !(RowIsInvalid() || ColumnIsInvalid() || HasFieldBeenTaken());
        }

        private bool RowIsInvalid()
        {
            return field.Intersection.Row < 1 || field.Intersection.Row > 3;
        }

        private bool ColumnIsInvalid()
        {
            return field.Intersection.Column < 1 || field.Intersection.Column > 3;
        }

        private bool HasFieldBeenTaken()
        {
            return FieldsPlayed.Any(x => x.Intersection.Row == field.Intersection.Row && x.Intersection.Column == field.Intersection.Column);
        }
    }
}