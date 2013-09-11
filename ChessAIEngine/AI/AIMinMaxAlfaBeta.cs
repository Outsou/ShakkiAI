using System;
using System.Collections.Generic;
using System.Text;
using ChessEngine.Engine;
using System.Diagnostics;

namespace ChessEngine.AI
{
    class AIMinMaxAlfaBeta : InterfaceAI
    {
        private AIBoardEvaluator evaluator = new AIBoardEvaluator();
        private AIMove bestMove;
        private int maxDepth;
        byte fiftyMove;

        public AIMove GetAIMove(Engine.Engine engine)
        {
            bestMove = new AIMove();
            maxDepth = 2;
            fiftyMove = engine.ChessBoard.FiftyMove;

            MinMaxAflaBeta(maxDepth, -double.MinValue, -Double.MaxValue, engine, ChessPieceColor.Black);

            engine.ChessBoard.FiftyMove = fiftyMove;
            engine.ChessBoard.StaleMate = false;

            return bestMove;
        }

        private double MinMaxAflaBeta(int depth, double alfa, double beta, ChessEngine.Engine.Engine engine, ChessPieceColor WhoseMove)
        {
            if (depth == 0)
            {
                return evaluator.ValuateBoard(engine.ChessBoard.Squares);
            }

            double positionValue = 0.0;

            engine.GenerateValidMoves();

            //Find all pieces that can be moved on this turn
            List<int> pieceList = new List<int>();
            Square[] squares = engine.ChessBoard.Squares;

            for (byte i = 0; i < squares.Length; i++)
            {
                if (i == 63)
                {
                }

                if (squares[i].Piece != null && squares[i].Piece.PieceColor == WhoseMove && squares[i].Piece.ValidMoves.Count > 0)
                {
                    //Debug.WriteLine("" + i + "|" + WhoseMove + "|" +squares[i].Piece.PieceType);

                    if (i == 18 && WhoseMove == ChessPieceColor.Black && squares[i].Piece.PieceType == ChessPieceType.King)
                    {
                    }

                    List<byte> moves = new List<byte>();
                    foreach (byte move in squares[i].Piece.ValidMoves)
                    {
                        moves.Add(move);
                    }

                    foreach (byte move in moves)
                    {
                        byte[] sourcePosition = CalculatePiecePosition(i);
                        byte[] destinationPosition = CalculatePiecePosition(move);

                        ChessPieceColor whoseMove = engine.WhoseMove;

                        //Copy old board
                        Board oldBoard = engine.ChessBoard.FastCopy();
                        MoveContent lastMove = engine.ChessBoard.LastMove;

                        //Make move
                        engine.MovePieceForAI(sourcePosition[0], sourcePosition[1], destinationPosition[0], destinationPosition[1], true);
                        debugWrite(engine);
                        if (WhoseMove == ChessPieceColor.Black)
                        {
                            WhoseMove = ChessPieceColor.White;
                        }
                        else
                        {
                            WhoseMove = ChessPieceColor.Black;
                        }


                        positionValue = -MinMaxAflaBeta(depth - 1, -alfa, -beta, engine, WhoseMove);

                        //Undo move
                        engine.ChessBoard = oldBoard;
                        engine.ChessBoard.LastMove = lastMove;

                        if (destinationPosition[0] == 2 && destinationPosition[1] == 3 && sourcePosition[0] == 2 && sourcePosition[1] == 2)
                        {
                        }

                        //Debug.WriteLine("" + destinationPosition[0] + destinationPosition[1] + sourcePosition[0] + sourcePosition[1]);

                        debugWrite(engine);
                        engine.WhoseMove = whoseMove;

                        if (depth == 2)
                        {
                        }

                         if (depth == 3)
                        {
                        }

                        /*
                        if (positionValue >= beta)
                        {
                            return beta;
                        }
                        */

                         if (maxDepth == maxDepth)
                         {
                             alfa = -alfa;
                         }

                        if (positionValue > alfa)
                        {
                            alfa = positionValue;

                            if (maxDepth == depth && engine.ChessBoard.Squares[i].Piece.PieceColor != ChessPieceColor.White)
                            {
                                bestMove.SourceColumn = sourcePosition[0];
                                bestMove.SourceRow = sourcePosition[1];
                                bestMove.DestinationColumn = destinationPosition[0];
                                bestMove.DestinationRow = destinationPosition[1];
                            }
                        }
                    }
                }
            }

            return alfa;
        }

        private byte[] CalculatePiecePosition(byte position)
        {
            byte SquareCount = 7;
            byte Row = 0;

            while (SquareCount < 64)
            {
                if (position <= SquareCount)
                {
                    break;
                }

                Row++;
                SquareCount += 8;
            }

            byte Column = (byte)(position - Row * 8);

            return new byte[2] {Column, Row};
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
                    line += square.Piece.PieceType.ToString().Substring(0, 1);
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
    }
}
