using System.Collections.Generic;

namespace TicTacToeKata
{
    public interface IBoard
    {
        int NumberOfFieldsPlayed { get; }
        List<Field> FieldsPlayed { get; }

        void Place(Intersection intersection, Player player);
        bool IsBoardFull();
    }
}