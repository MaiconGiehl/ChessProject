using System.Collections.Generic;
using board;

namespace Chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;

        public ChessMatch ()
        {
            Board = new Board(8,8);
            Shift = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece> ();
            Captured = new HashSet<Piece> ();
            PutPieces();
        }


        public void DoMovement (Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovQty();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PutPiece(p, destiny);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
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

        public void DestinyValidate (Position origin, Position destiny)
        {
            if(!Board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny position!");
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

        public HashSet<Piece> CapturedPieces (Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece> ();
            foreach (Piece x in Captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame (Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece> ();
            foreach (Piece x in Captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void PutNewPiece (char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }
        private void PutPieces ()
        {
            PutNewPiece('c', 1, new Rook(Board, Color.White));
            PutNewPiece('c', 2, new Rook(Board, Color.White));
            PutNewPiece('d', 2, new Rook(Board, Color.White));
            PutNewPiece('e', 2, new Rook(Board, Color.White));
            PutNewPiece('e', 1, new Rook(Board, Color.White));
            PutNewPiece('d', 1, new King(Board, Color.White));

            PutNewPiece('c', 7, new Rook(Board, Color.Black));
            PutNewPiece('c', 8, new Rook(Board, Color.Black));
            PutNewPiece('d', 7, new Rook(Board, Color.Black));
            PutNewPiece('e', 7, new Rook(Board, Color.Black));
            PutNewPiece('e', 8, new Rook(Board, Color.Black));
            PutNewPiece('d', 8, new King(Board, Color.Black));
        }
    }
}
