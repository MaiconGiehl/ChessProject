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
        public bool Check { get; private set; }
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }


        public Piece DoMovement(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovQty();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PutPiece(p, destiny);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(destiny);
            p.DescreaseMovQty();
            if (capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, destiny);
                Captured.Remove(capturedPiece);
            }
            Board.PutPiece(p, origin);
        }

        public void MakeMove(Position origin, Position destiny)
        {
            Piece capturedPiece = DoMovement(origin, destiny);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMove(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if (IsInCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (TestCheckmate(Adversary(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Shift++;
                ChangePlayer();
            }

        }

        public void OriginValidate(Position pos)
        {
            if (Board.piece(pos) == null)
            {
                throw new BoardException("There's not any piece in the choosen origin!");
            }
            if (CurrentPlayer != Board.piece(pos).Color)
            {
                throw new BoardException("The choosen piece isn't yours!");
            }
            if (!Board.piece(pos).DoMovesExist())
            {
                throw new BoardException("The choosen piece can't move to nowhere");
            }
        }

        public void DestinyValidate(Position origin, Position destiny)
        {
            if (!Board.piece(origin).PossibleMovement(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }
        public void ChangePlayer()
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

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardException("There's not a king of the " + color + " color on the board!");
            }
            foreach (Piece x in PiecesInGame(Adversary(color)))
            {
                bool[,] mat = x.ValidMovements();
                if (mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestCheckmate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInGame(color))
            {
                bool[,] mat = x.ValidMovements();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Lines; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = DoMovement(origin, destiny);
                            bool testCheck = IsInCheck(color);
                            UndoMove(origin, destiny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }
        private void PutPieces()
        {
            PutNewPiece('a', 1, new King(Board, Color.White));
            PutNewPiece('a', 8, new King(Board, Color.Black));


            PutNewPiece('d', 4, new Knight(Board, Color.White));
            PutNewPiece('e', 4, new Bishop(Board, Color.White));

            PutNewPiece('d', 5, new Knight(Board, Color.Black));
            PutNewPiece('e', 5, new Bishop(Board, Color.Black));
        }
    }
}
