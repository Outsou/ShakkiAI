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
            maxDepth = 5;
            fiftyMove = engine.ChessBoard.FiftyMove;

            double alfa = double.MinValue;
            double beta = double.MaxValue;

            MaxValue(maxDepth, alfa, beta, engine);

            engine.ChessBoard.FiftyMove = fiftyMove;
            engine.ChessBoard.StaleMate = false;

            return bestMove;
        }

        private double MaxValue(int depth, double alfa, double beta, ChessEngine.Engine.Engine engine)
        {
            //Debug.WriteLine("old");
            //debugWrite(engine);

            if (depth == 0)
            {
                double boardValue = evaluator.ValuateBoard(engine.ChessBoard.Squares);
                if (boardValue == 0)
                {
                }
                //debugWrite(engine);
                return -boardValue;
            }

            double v = Double.MinValue;

            //Find all pieces that can be moved on this turn
            List<int> pieceList = ReturnAllMovablePieces(engine);

            foreach (int piece in pieceList)
            {
                foreach (byte move in engine.ChessBoard.Squares[piece].Piece.ValidMoves)
                {

                    ChessEngine.Engine.Engine newState = ReturnNewState(engine, (byte)(piece), move);
                    //debugWrite(newState);

                    double oldV = v;
                    v = Math.Max(v, MinValue(depth-1, alfa, beta, newState));

                    if (v > alfa)
                    {
                        alfa = v;

                        if (depth == maxDepth)
                        {
                            byte[] source = CalculatePiecePosition((byte)(piece));
                            byte[] destination = CalculatePiecePosition(move);
                            bestMove.SourceColumn = source[0];
                            bestMove.SourceRow = source[1];
                            bestMove.DestinationColumn = destination[0];
                            bestMove.DestinationRow = destination[1];
                        }
                        else
                        {
                            return v;
                        }                   
                    }

                    alfa = Math.Max(alfa, v);
                }
            }

            return v;
        }

        private double MinValue(int depth, double alfa, double beta, ChessEngine.Engine.Engine engine)
        {
            //Debug.WriteLine("old");
            //debugWrite(engine);

            if (depth == 0)
            {
                double boardValue = evaluator.ValuateBoard(engine.ChessBoard.Squares);
                if (boardValue == 0)
                {
                }
                return -boardValue;
            }

            double v = Double.MaxValue;

            List<int> pieceList = ReturnAllMovablePieces(engine);

            foreach (int piece in pieceList)
            {
                foreach (byte move in engine.ChessBoard.Squares[piece].Piece.ValidMoves)
                {
                    ChessEngine.Engine.Engine newState = ReturnNewState(engine, (byte)(piece), move);
                    //debugWrite(newState);

                    v = Math.Min(v, MaxValue(depth - 1, alfa, beta, newState));

                    if (v < beta)
                    {
                        beta = v;
                        return v;
                    }

                    beta = Math.Min(beta, v);
                }
            }

            return v;
        }

        private ChessEngine.Engine.Engine ReturnNewState(ChessEngine.Engine.Engine engine, byte piece, byte move)
        {
            ChessEngine.Engine.Engine newState = new Engine.Engine();
            newState.ChessBoard = new Board(engine.ChessBoard);
            byte[] sourcePos = CalculatePiecePosition((byte)(piece));
            byte[] destinationPos = CalculatePiecePosition(move);

            newState.MovePieceForAI(sourcePos[0], sourcePos[1], destinationPos[0], destinationPos[1], true);

            return newState;
        }

        private List<int> ReturnAllMovablePieces(ChessEngine.Engine.Engine engine)
        {
            List<int> pieceList = new List<int>();
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
    }
}
