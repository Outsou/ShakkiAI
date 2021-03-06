using System;
using System.Collections.Generic;
using ChessEngine.AI;

[assembly: CLSCompliant(true)]

namespace ChessEngine.Engine
{
    public sealed class Engine
    {
        internal Board ChessBoard;
        internal Board PreviousChessBoard;

        internal InterfaceAI AIblack;
        internal InterfaceAI AIwhite;

        public ChessPieceColor HumanPlayer;

        public ChessPieceColor WhoseMove
        {
            get { return ChessBoard.WhoseMove; }
            set { ChessBoard.WhoseMove = value; }
        }

        public Engine()
        {           
            InitiateBoard("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            //InitiateBoard("4k3/8/8/8/8/8/3Q4/QQQQKQQQ w KQkq - 0 1");
            //InitiateBoard("4k3/8/8/8/8/8/8/3NK3 w KQkq - 0 1");
            //InitiateBoard("8/3k4/8/8/8/8/8/3NK3 w KQkq - 0 1");
            //InitiateBoard("7k/8/P7/8/8/8/8/4K8 w KQkq - 0 1");
        }

        public Engine(string fen)
        {
            InitiateBoard(fen);
        }

        private void InitiateBoard(string fen)
        {
            AIblack = new AIMinMaxAlfaBeta();
            AIwhite = new AIrandom();
            HumanPlayer = ChessPieceColor.White;    
            ChessBoard = new Board(fen);
            ChessBoard.WhoseMove = ChessPieceColor.White;
            PieceMoves.InitiateChessPieceMotion();
            GenerateValidMoves();           
        }

        public byte[] GetEnPassantMoves()
        {
            if (ChessBoard == null)
            {
                return null;
            }

            var returnArray = new byte[2];

            returnArray[0] = (byte)(ChessBoard.EnPassantPosition % 8);
            returnArray[1] = (byte)(ChessBoard.EnPassantPosition / 8);

            return returnArray;
        }

        public bool IsValidMove(byte sourceColumn, byte sourceRow, byte destinationColumn, byte destinationRow)
        {
            if (ChessBoard == null)
            {
                return false;
            }

            if (ChessBoard.Squares == null)
            {
                return false;
            }

            byte index = GetBoardIndex(sourceColumn, sourceRow);

            if (ChessBoard.Squares[index].Piece == null)
            {
                return false;
            }

            foreach (byte bs in ChessBoard.Squares[index].Piece.ValidMoves)
            {
                if (bs % 8 == destinationColumn)
                {
                    if ((byte)(bs / 8) == destinationRow)
                    {
                        return true;
                    }
                }
            }

            index = GetBoardIndex(destinationColumn, destinationRow);

            if (index == ChessBoard.EnPassantPosition)
            {
                return true;
            }

            return false;
        }

        public ChessPieceType GetPieceTypeAt(byte boardColumn, byte boardRow)
        {
            byte index = GetBoardIndex(boardColumn, boardRow);

            if (ChessBoard.Squares[index].Piece == null)
            {
                return ChessPieceType.None;
            }

            return ChessBoard.Squares[index].Piece.PieceType;
        }

        public ChessPieceType GetPieceTypeAt(byte index)
        {
            if (ChessBoard.Squares[index].Piece == null)
            {
                return ChessPieceType.None;
            }

            return ChessBoard.Squares[index].Piece.PieceType;
        }

        public ChessPieceColor GetPieceColorAt(byte boardColumn, byte boardRow)
        {
            byte index = GetBoardIndex(boardColumn, boardRow);

            if (ChessBoard.Squares[index].Piece == null)
            {
                return ChessPieceColor.White;
            }
            return ChessBoard.Squares[index].Piece.PieceColor;
        }

        public ChessPieceColor GetPieceColorAt(byte index)
        {
            if (ChessBoard.Squares[index].Piece == null)
            {
                return ChessPieceColor.White;
            }
            return ChessBoard.Squares[index].Piece.PieceColor;
        }

        public bool GetChessPieceSelected(byte boardColumn, byte boardRow)
        {
            byte index = GetBoardIndex(boardColumn, boardRow);

            if (ChessBoard.Squares[index].Piece == null)
            {
                return false;
            }

            return ChessBoard.Squares[index].Piece.Selected;
        }

        public byte[][] GetValidMoves(byte boardColumn, byte boardRow)
        {
            byte index = GetBoardIndex(boardColumn, boardRow);

            if (ChessBoard.Squares[index].Piece ==
                null)
            {
                return null;
            }

            var returnArray = new byte[ChessBoard.Squares[index].Piece.ValidMoves.Count][];
            int counter = 0;

            foreach (byte square in ChessBoard.Squares[index].Piece.ValidMoves)
            {
                returnArray[counter] = new byte[2];
                returnArray[counter][0] = (byte)(square % 8);
                returnArray[counter][1] = (byte)(square / 8);
                counter++;
            }

            return returnArray;
        }

        public void SetChessPieceSelection(byte boardColumn, byte boardRow,
                                          bool selection)
        {
            byte index = GetBoardIndex(boardColumn, boardRow);

            if (ChessBoard.Squares[index].Piece == null)
            {
                return;
            }
            //if (ChessBoard.squares[index].Piece.PieceColor != HumanPlayer)
            //{
            //    return;
            //}
            if (ChessBoard.Squares[index].Piece.PieceColor != WhoseMove)
            {
                return;
            }
            ChessBoard.Squares[index].Piece.Selected = selection;
        }

        public bool MovePiece(byte sourceColumn, byte sourceRow, byte destinationColumn, byte destinationRow)
        {
            byte srcPosition = (byte)(sourceColumn + (sourceRow * 8));
            byte dstPosition = (byte)(destinationColumn + (destinationRow * 8));

            Piece piece = ChessBoard.Squares[srcPosition].Piece;

            PreviousChessBoard = new Board(ChessBoard);

            Board.MovePiece(ChessBoard, srcPosition, dstPosition, ChessPieceType.Queen);

            PieceValidMoves.GenerateValidMoves(ChessBoard);

            //If there is a check in place, check if this is still true;
            if (piece.PieceColor == ChessPieceColor.White)
            {
                if (ChessBoard.WhiteCheck)
                {
                    //Invalid Move
                    ChessBoard = new Board(PreviousChessBoard);
                    PieceValidMoves.GenerateValidMoves(ChessBoard);
                    return false;
                }
            }
            else if (piece.PieceColor == ChessPieceColor.Black)
            {
                if (ChessBoard.BlackCheck)
                {
                    //Invalid Move
                    ChessBoard = new Board(PreviousChessBoard);
                    PieceValidMoves.GenerateValidMoves(ChessBoard);
                    return false;
                }
            }

            return true;
        }

        public void GenerateValidMoves()
        {
            PieceValidMoves.GenerateValidMoves(ChessBoard);
        }

        private static byte GetBoardIndex(byte BoardColumn, byte BoardRow)
        {
            return (byte)(BoardColumn + (BoardRow * 8));
        }

        #region Methods added by Otto

        public bool MovePieceAI()
        {
            AIMove AIMove;
            if (WhoseMove == ChessPieceColor.Black)
            {
                AIMove = AIblack.GetAIMove(this);
            }
            else
            {
                AIMove = AIwhite.GetAIMove(this);
            }

            //No moves
            if (AIMove == null)
            {
                return false;
            }

            return MovePiece(AIMove.SourceColumn, AIMove.SourceRow, AIMove.DestinationColumn, AIMove.DestinationRow);
        }

        public bool IsBlackChecked()
        {
            return ChessBoard.BlackCheck;
        }

        public bool IsWhiteChecked()
        {
            return ChessBoard.WhiteCheck;
        }

        public bool IsStalemateBy50MoveRule()
        {
            return ChessBoard.StaleMate;
        }

        public byte[] CalculateColumnAndRow(byte position)
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

            return new byte[2] { Column, Row };
        }

        public bool IsCheckMate()
        {
            bool checkMate = false;

            if ((IsBlackChecked() && WhoseMove == ChessPieceColor.Black) || (IsWhiteChecked() && WhoseMove == ChessPieceColor.White))
            {
                checkMate = true;
                DynamicArray pieceList = new DynamicArray();
                Square[] squares = ChessBoard.Squares;
                Board oldBoard = new Board(ChessBoard);

                byte[] sourcePos;
                byte[] destinationPos;

                //Find all pieces that can be moved on this turn
                for (byte i = 0; i < squares.Length; i++)
                {
                    if (squares[i].Piece != null && squares[i].Piece.PieceColor == WhoseMove && squares[i].Piece.ValidMoves.Count > 0)
                    {
                        pieceList.Add(i);
                    }
                }

                //If piecelist is empty, no moves can be made
                if (pieceList.Count == 0)
                {
                    return false;
                }

                foreach (byte piece in pieceList)
                {
                    sourcePos = CalculateColumnAndRow(piece);
                    foreach (byte move in squares[piece].Piece.ValidMoves)
                    {
                        destinationPos = CalculateColumnAndRow(move);

                        if (MovePiece(sourcePos[0], sourcePos[1], destinationPos[0], destinationPos[1]))
                        {
                            ChessBoard = new Board(oldBoard);
                            PieceValidMoves.GenerateValidMoves(ChessBoard);
                            return false;
                        }
                    }
                }
            }

            return checkMate;
        }

        public void SetMaxDepth(int depth)
        {
            AIblack.SetMaxDepth(depth);
        }

        public void SetMaxTime(int time)
        {
            AIblack.SetMaxTime(time);
        }

        #endregion
    }
}