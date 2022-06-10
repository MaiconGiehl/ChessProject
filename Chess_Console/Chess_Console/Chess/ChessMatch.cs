using System;
using board;

namespace Chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        public ChessMatch ()
        {
            Board = new Board(8,8);
            Shift = 1;
            CurrentPlayer = Color.White;
            PutPieces();
        }


        public void DoMovement (Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovQty();
            Piece CapturedPiece = Board.RemovePiece(destiny);
            Board.PutPiece(p, destiny);
        }

        public void MakeMove (Position origin, Position destiny)
        {
            DoMovement (origin, destiny);
            Shift++;
            ChangePlayer();
        }

        public void OriginValidate (Position pos)
        {
            if (Board.piece(pos) == null)
            {
                throw new BoardException("There's not any piece in the choosen origin!");
            }
            if(CurrentPlayer != Board.piece(pos).Color)
            {
                throw new BoardException("The choosen piece isn't yours!");
            }
            if (!Board.piece(pos).DoMovesExist())
            {
                throw new BoardException("The choosen piece can't move to nowhere");
            }
        }

        public void ChangePlayer ()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        private void PutPieces ()
        {
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());
                                    

            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());

        }
    }
}
