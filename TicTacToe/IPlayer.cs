using System;
namespace TicTacToe
{
    public interface IPlayer
    {
        Board CurrentBoard {get; set;}
        void PlayTurn();
    }
}
