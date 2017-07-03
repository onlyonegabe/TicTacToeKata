using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class Board : IBoard
    {
        private Field field;
        private int width;
        private int height;

        public int NumberOfFieldsPlayed { get { return FieldsPlayed.Count; } }
        public List<Field> FieldsPlayed { get; private set; }
        
        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
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

        public bool AreAllFieldsPlayed()
        {
            return NumberOfFieldsPlayed == (width * height);
        }

        private bool IsMoveValid()
        {
            return !(RowIsInvalid() || ColumnIsInvalid() || HasFieldBeenTaken());
        }

        private bool RowIsInvalid()
        {
            return field.Intersection.Row < 1 || field.Intersection.Row > height;
        }

        private bool ColumnIsInvalid()
        {
            return field.Intersection.Column < 1 || field.Intersection.Column > width;
        }

        private bool HasFieldBeenTaken()
        {
            return FieldsPlayed.Any(x => x.Intersection.Row == field.Intersection.Row && x.Intersection.Column == field.Intersection.Column);
        }        
    }
}