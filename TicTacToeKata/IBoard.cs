using System.Collections.Generic;

namespace TicTacToeKata
{
    public interface IBoard
    {
        int CountOfFieldsPlayed { get; }
        List<Field> FieldsPlayed { get; }

        void Place(Intersection intersection, Player player);
        bool AreAllFieldsPlayed();
    }
}