using System;
using System.Collections.Generic;
using System.Text;
using ChessEngine.Engine;
using System.Diagnostics;

namespace ChessEngine.AI
{
    class AIMinMaxAlfaBeta : InterfaceAI
    {
        private AIBoardEvaluator evaluator;
        private AIMove bestMove;
        private Stopwatch timer;
        private int maxDepth;
        private TimeSpan maxTime;
        private bool overTime;

        //Constructor
        public AIMinMaxAlfaBeta()
        {
            evaluator = new AIBoardEvaluator();
            timer = new Stopwatch();
            maxDepth = 3;
            maxTime = new TimeSpan(0, 0, 0);
        }

        public AIMove GetAIMove(Engine.Engine engine)
        {
            overTime = false;
            bestMove = new AIMove();
            timer.Reset();
            timer.Start();
            MaxValue(maxDepth, double.MinValue, double.MaxValue, engine);

            //No legal move was found
            if (bestMove.DestinationColumn == 0 && bestMove.DestinationRow == null && bestMove.SourceColumn == 0 && bestMove.SourceRow == null)
            {
                return null;
            }

            return bestMove;
        }

        private double MaxValue(int depth, double alpha, double beta, ChessEngine.Engine.Engine engine)
        {
            //Check if stalemate
            if (engine.IsStalemateBy50MoveRule())
            {
                return 0;
            }

            //Check if checkmate
            if (engine.IsCheckMate())
            {
                return Double.MinValue;
            }

            //A leaf node, return value of board state
            if ((depth == 0 && maxDepth != 0) || (maxTime.Seconds != 0 && timer.Elapsed > maxTime))
            {
                if (maxTime.Seconds != 0 && timer.Elapsed > maxTime)
                {
                    overTime = true;
                }

                double boardValue = evaluator.ValuateBoard(engine.ChessBoard.Squares);
                return boardValue;
            }

            double value = Double.MinValue;

            //Find all pieces that can be moved on this turn
            DynamicArray pieceList = ReturnAllMovablePieces(engine);

            //Go through all possible moves
            foreach (byte piece in pieceList)
            {
                foreach (byte move in engine.ChessBoard.Squares[piece].Piece.ValidMoves)
                {
                    //Create the next board stage
                    ChessEngine.Engine.Engine newState = ReturnNewState(engine, piece, move);

                    //Invalid move, continue to next move
                    if (newState == null)
                    {
                        continue;
                    }

                    //Pass parameters to the next node
                    value = MinValue(depth-1, alpha, beta, newState);

                    //Check if alpha can be given bigger value
                    if (value > alpha)
                    {
                        alpha = value;

                        if (depth == maxDepth)
                        {
                            //Back at the root node with a better move than the previous best
                            byte[] source = engine.CalculateColumnAndRow(piece);
                            byte[] destination = engine.CalculateColumnAndRow(move);
                            bestMove.SourceColumn = source[0];
                            bestMove.SourceRow = source[1];
                            bestMove.DestinationColumn = destination[0];
                            bestMove.DestinationRow = destination[1];
                        }               
                    }

                    //If alpha is bigger than beta, don't investigate branch further
                    if (alpha > beta)
                    {
                        return alpha;
                    }

                    if (overTime)
                    {
                        break;
                    }
                }

                if (overTime)
                {
                    break;
                }
            }
            return alpha;
        }

        private double MinValue(int depth, double alpha, double beta, ChessEngine.Engine.Engine engine)
        {
            //Check if stalemate
            if (engine.IsStalemateBy50MoveRule())
            {
                return 0;
            }

            //Check if checkmate
            if (engine.IsCheckMate())
            {
                return Double.MaxValue;
            }

            //A leaf node, return value of board state
            if ((depth == 0 && maxDepth != 0) || (maxTime.Seconds != 0) && timer.Elapsed > maxTime)
            {
                if (maxTime.Seconds != 0 && timer.Elapsed > maxTime)
                {
                    overTime = true;
                }

                double boardValue = evaluator.ValuateBoard(engine.ChessBoard.Squares);
                return boardValue;
            }

            double value = Double.MaxValue;

            //Find all pieces that can be moved on this turn
            DynamicArray pieceList = ReturnAllMovablePieces(engine);

            //Go through all possible moves
            foreach (byte piece in pieceList)
            {
                foreach (byte move in engine.ChessBoard.Squares[piece].Piece.ValidMoves)
                {
                    //Create the next board stage and pass it to the next node
                    ChessEngine.Engine.Engine newState = ReturnNewState(engine, piece, move);

                    //Invalid move, continue to next move
                    if (newState == null)
                    {
                        continue;
                    }

                    value = MaxValue(depth - 1, alpha, beta, newState);

                    //Check if beta can be given smaller value
                    if (value < beta)
                    {
                        beta = value; 
                    }

                    //If beta is smaller than alpha, don't investigate branch further
                    if (beta < alpha)
                    {
                        return beta;
                    }

                    if (overTime)
                    {
                        break;
                    }
                }

                if (overTime)
                {
                    break;
                }
            }
            return beta;
        }

        private ChessEngine.Engine.Engine ReturnNewState(ChessEngine.Engine.Engine engine, byte piece, byte move)
        {
            ChessEngine.Engine.Engine newState = new Engine.Engine();
            newState.ChessBoard = new Board(engine.ChessBoard);
            byte[] sourcePos = engine.CalculateColumnAndRow((byte)(piece));
            byte[] destinationPos = engine.CalculateColumnAndRow(move);

            if (!newState.MovePiece(sourcePos[0], sourcePos[1], destinationPos[0], destinationPos[1]))
            {
                return null;
            }

            return newState;
        }

        private DynamicArray ReturnAllMovablePieces(ChessEngine.Engine.Engine engine)
        {
            DynamicArray pieceList = new DynamicArray();
            Square[] squares = engine.ChessBoard.Squares;

            //Find all pieces that can be moved on this turn
            for (byte i = 0; i < squares.Length; i++)
            {
                if (squares[i].Piece != null && squares[i].Piece.PieceColor == engine.WhoseMove && squares[i].Piece.ValidMoves.Count > 0)
                {
                    pieceList.Add(i);
                }
            }

            return pieceList;
        }

        private void debugWrite(ChessEngine.Engine.Engine engine)
        {
            string line = "";
            for (int i = 0; i < engine.ChessBoard.Squares.Length; i++)
            {
                if (i == 59)
                {
                }

                Square square = engine.ChessBoard.Squares[i];

                if (square.Piece != null)
                {
                    if (square.Piece.PieceType == ChessPieceType.Knight)
                    {
                        line += "H";
                    }
                    else
                    {
                        line += square.Piece.PieceType.ToString().Substring(0, 1);
                    }
                }
                else
                {
                    line += ".";
                }

                if ((i + 1) % 8 == 0)
                {
                    Debug.WriteLine(line);
                    line = "";
                }
            }
            Debug.WriteLine("\n\n\n");
        }

        public void SetMaxDepth(int depth)
        {
            maxDepth = depth;
        }

        public void SetMaxTime(int time)
        {
            maxTime = new TimeSpan(0, 0, time);
        }
    }
}
