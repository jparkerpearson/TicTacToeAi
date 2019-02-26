using System;
using System.Collections.Generic;
namespace TicTacToe
{
    public class Game
    {
        private Board currentGameBoard;
        private IPlayer player1;
        private IPlayer player2;

        public Game()
        {
            currentGameBoard = new Board();
            player1 = new HumanPlayer(currentGameBoard, SquareState.X);
            player2 = new AiPlayer(currentGameBoard, SquareState.Circle);
        }

        public void PlayGame(){
            while (!currentGameBoard.IsGameOver()){
                player1.PlayTurn();
                currentGameBoard.PrintBoard();
                if (currentGameBoard.IsGameOver()){
                    break;
                }
                player2.PlayTurn();
                currentGameBoard.PrintBoard();
            }
            Console.WriteLine("GAME OVER!");

        }
    }
}
