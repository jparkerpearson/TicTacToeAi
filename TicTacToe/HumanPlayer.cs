using System;
namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        public Board CurrentBoard { get; set; }
        private SquareState mySide;

        public HumanPlayer(Board emptyBoard, SquareState side) 
        {
            CurrentBoard = emptyBoard;
            mySide = side;
        }


        public void PlayTurn()
        {
            Console.WriteLine("Enter Position To play at");
            int position = Convert.ToInt32(Console.ReadLine());
            // todo ensure the selected position is valid
            CurrentBoard.PlayTurn(position, mySide);
        }
    }
}
