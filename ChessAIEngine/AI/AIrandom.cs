using System;
using System.Collections.Generic;
using System.Text;
using ChessEngine.Engine;

namespace ChessEngine.AI
{
    class AIrandom : InterfaceAI
    {
        private AIMove AIMove = new AIMove();
        private List<byte> PieceList = new List<byte>();
        private Square[] Squares;
        private ChessPieceColor WhoseTurn;
        private Random RandomGenerator = new Random();
        private byte[][] LegalMoves;

        public AIMove GetAIMove(ChessEngine.Engine.Engine engine)
        {
            PieceList.Clear();

            Squares = engine.ChessBoard.Squares;
            WhoseTurn = engine.WhoseMove;

            //Find all pieces that can be moved on this turn
            for (byte i = 0; i < Squares.Length; i++)
            {
                if (Squares[i].Piece != null && Squares[i].Piece.PieceColor == WhoseTurn && Squares[i].Piece.ValidMoves.Count > 0)
                {
                    PieceList.Add(i);
                }
            }

            //Randomly select Piece
            byte Piece = PieceList[RandomGenerator.Next(0, PieceList.Count)];

            //Calculate piece position
            byte SquareCount = 7;
            byte Row = 0;

            while (SquareCount < 64)
            {
                if (Piece <= SquareCount)
                {
                    break;
                }

                Row++;
                SquareCount += 8;
            }

            byte Column = (byte)(Piece - Row * 8);

            AIMove.SourceRow = Row;
            AIMove.SourceColumn = Column;

            //Randomly select a move
            LegalMoves = engine.GetValidMoves(Column, Row);

            int MoveIndex = RandomGenerator.Next(0, LegalMoves.Length);

            AIMove.DestinationRow = LegalMoves[MoveIndex][1];
            AIMove.DestinationColumn = LegalMoves[MoveIndex][0];

            Console.WriteLine("(" + AIMove.SourceColumn + ", " + AIMove.SourceRow + ")" + "   (" + AIMove.DestinationColumn + ", " + AIMove.DestinationRow + ")" + "\n---------------");

            return AIMove;
        }
    }
}
