using System;
using board;

namespace Chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        private int round;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }
        public ChessMatch ()
        {
            board = new Board(8,8);
            round = 1;
            CurrentPlayer = Color.White;
            PutPieces();
        }

        public void DoMovement (Position origin, Position destiny)
        {
            Piece p = board.RemovePiece(origin);
            p.IncreaseMovQty();
            Piece CapturedPiece = board.RemovePiece(destiny);
            board.PutPiece(p, destiny);
        }

        private void PutPieces ()
        {
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('c', 1).ToPosition());
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('c', 2).ToPosition());
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('d', 2).ToPosition());
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('e', 2).ToPosition());
            board.PutPiece(new Rook(board, Color.White), new ChessPosition('e', 1).ToPosition());
            board.PutPiece(new King(board, Color.White), new ChessPosition('d', 1).ToPosition());



            board.PutPiece(new Rook(board, Color.Black), new ChessPosition('c', 7).ToPosition());
            board.PutPiece(new Rook(board, Color.Black), new ChessPosition('c', 8).ToPosition());
            board.PutPiece(new Rook(board, Color.Black), new ChessPosition('d', 7).ToPosition());
            board.PutPiece(new Rook(board, Color.Black), new ChessPosition('e', 7).ToPosition());
            board.PutPiece(new Rook(board, Color.Black), new ChessPosition('e', 8).ToPosition());
            board.PutPiece(new King(board, Color.Black), new ChessPosition('d', 8).ToPosition());


        }
    }
}
