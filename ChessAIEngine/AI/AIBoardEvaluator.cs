using System;
using System.Collections.Generic;
using System.Text;
using ChessEngine.Engine;

namespace ChessEngine.AI
{
    class AIBoardEvaluator
    {
        public double ValuateBoard(Square[] board)
        {
            double value = 0.0;
            short pieceValue = 0;

            foreach (Square square in board)
            {
                if (square.Piece != null)
                {

                    pieceValue = square.Piece.PieceValue;

                    if (square.Piece.PieceColor == ChessPieceColor.White)
                    {
                        value += pieceValue;
                    }
                    else
                    {
                        value -= pieceValue;
                    }
                }
            }

            return value;
        }
    }
}
