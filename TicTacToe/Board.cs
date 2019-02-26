using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        public IList<SquareState> CurrentBoard { get; set; }
        public const int CIRCLE_VALUE = -100;
        public const int X_VALUE = 100;

        public Board(){
            CurrentBoard = new List<SquareState>();
            for (int i = 0; i < 9; i++){
                CurrentBoard.Add(SquareState.Empty);
            }
        }

        public void PlayTurn(int position, SquareState turn){
            CurrentBoard[position] = turn;
        }


        public void PrintBoard(){
            for (int i = 0; i < 9; i++){
                if (i%3 == 0){
                    Console.WriteLine();
                }
                Console.Write(CurrentBoard[i] + "|");
            }
            Console.WriteLine();
        }

        public bool IsGameOver(){
            var currentState = GetBoardState(CurrentBoard);
            if (currentState == CIRCLE_VALUE){
                Console.WriteLine("Circle's Wins");
                return true;
            }
            if (currentState == X_VALUE){
                Console.WriteLine("X's wins");
                return true;
            }
            foreach (var state in CurrentBoard){
                if (state == SquareState.Empty){
                    return false;
                }
            }
            return true;
        }

        public int GetBoardState(IList<SquareState> boardToAnalyze){
            // return 100 if x has one
            // return -100 if circle won 
            // return 0 if game not over

            var wonByRows = CheckRows(boardToAnalyze);
            if (wonByRows != 0){
                return wonByRows;
            }
            var wonByCols = CheckCols(boardToAnalyze);
            if (wonByCols != 0){
                return wonByCols;
            }
            var wonByDiags = CheckDiagnols(boardToAnalyze);
            if (wonByDiags != 0){
                return wonByDiags;
            }
            return 0;
        }

        private int CheckRows(IList<SquareState> boardToCheck){
            for (int i = 0; i < 3; i++){
                if (boardToCheck[i*3 + 0] == SquareState.Circle &&
                    boardToCheck[i*3 + 1] == SquareState.Circle &&
                    boardToCheck[i*3+2] == SquareState.Circle)
                {
                    return CIRCLE_VALUE;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (boardToCheck[i * 3 + 0] == SquareState.X &&
                    boardToCheck[i * 3 + 1] == SquareState.X &&
                    boardToCheck[i * 3 + 2] == SquareState.X)
                {
                    return X_VALUE;
                }
            }
            return 0;

        }

        private int CheckCols(IList<SquareState> boardToCheck){
            for (int i = 0; i < 3; i++){
                if (boardToCheck[0 + i] == SquareState.X &&
                    boardToCheck[3 + i] == SquareState.X &&
                    boardToCheck[6 + i] == SquareState.X)
                {
                    return X_VALUE;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (boardToCheck[0 + i] == SquareState.Circle &&
                    boardToCheck[3 + i] == SquareState.Circle &&
                    boardToCheck[6 + i] == SquareState.Circle)
                {
                    return CIRCLE_VALUE;
                }
            }
            return 0;
        }

        private int CheckDiagnols(IList<SquareState> boardToCheck){
            if (boardToCheck[0] == SquareState.Circle &&
                    boardToCheck[4] == SquareState.Circle &&
                    boardToCheck[8] == SquareState.Circle)
            {
                return CIRCLE_VALUE;
            }
            if (boardToCheck[2] == SquareState.Circle &&
                    boardToCheck[4] == SquareState.Circle &&
                    boardToCheck[6] == SquareState.Circle)
            {
                return CIRCLE_VALUE;
            }
            if (boardToCheck[0] == SquareState.X &&
                    boardToCheck[4] == SquareState.X &&
                    boardToCheck[8] == SquareState.X)
            {
                return X_VALUE;
            }
            if (boardToCheck[2] == SquareState.X &&
                    boardToCheck[4] == SquareState.X &&
                    boardToCheck[6] == SquareState.X)
            {
                return X_VALUE;
            }
            return 0;
        }
    }
}
