using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class AiPlayer : IPlayer
    {
        private readonly SquareState myTeam;

        public Board CurrentBoard { get; set; }

        public AiPlayer(Board gameBoard, SquareState team)
        {
            CurrentBoard = gameBoard;
            myTeam = team;
        }


        public void PlayTurn()
        {
            var nextTurn = GetNextTurn();
            CurrentBoard.PlayTurn(nextTurn, myTeam);
        }

        private int GetNextTurn(){
            var bestMove = 150;
            var nextMove = -1;
            var moveWeights = new Dictionary<int, int>();
            for (int i = 0; i < CurrentBoard.CurrentBoard.Count; i++)
            {
                if (CurrentBoard.CurrentBoard[i] == SquareState.Empty)
                {
                    var bestWorstOutcome = SimulateMyNextMove(CurrentBoard.CurrentBoard, i);
                    moveWeights.Add(i, bestWorstOutcome);
                    if (bestWorstOutcome < bestMove)
                    {
                        nextMove = i;
                        bestMove = bestWorstOutcome;
                    }
                }
            }
            return nextMove;
        }

        // simulate my next move
        // simulate opponents next move
        private int SimulateMyNextMove(IList<SquareState> board, int position){
            var max = -200;

            var copyArray = new SquareState[board.Count];
            board.CopyTo(copyArray, 0);
            copyArray[position] = SquareState.Circle;

            var proposedList = new List<SquareState>();
            foreach (var state in copyArray)
            {
                proposedList.Add(state);
            }
            var currentState = CurrentBoard.GetBoardState(proposedList);
            if(currentState != 0 || !proposedList.Contains(SquareState.Empty) ){ // if the move ends the game
                return currentState;
            }

            for (int i = 0; i < proposedList.Count; i++ ){
                if (proposedList[i] == SquareState.Empty){
                    var opponentsBestState = SimulateOpponentsNextMove(proposedList, i);
                    if (opponentsBestState > max){
                        max = opponentsBestState;
                    }
                }
            }
            return max;
        }

        private int SimulateOpponentsNextMove(IList<SquareState> board, int position){
            var min = 200;

            var copyArray = new SquareState[board.Count];
            board.CopyTo(copyArray, 0);
            copyArray[position] = SquareState.X;

            var proposedList = new List<SquareState>();
            foreach (var state in copyArray)
            {
                proposedList.Add(state);
            }
            var currentState = CurrentBoard.GetBoardState(proposedList);
            if (currentState != 0 || !proposedList.Contains(SquareState.Empty))
            { // if the move ends the game
                return currentState;
            }

            for (int i = 0; i < proposedList.Count; i++)
            {
                if (proposedList[i] == SquareState.Empty)
                {
                    var opponentsBestState = SimulateMyNextMove(proposedList, i);
                    if (opponentsBestState < min)
                    {
                        min = opponentsBestState;
                    }
                }
            }
            return min;
        }
    }
}
