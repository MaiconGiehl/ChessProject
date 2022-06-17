using board;

namespace Chess
{
    internal class King : Piece
    {
        private ChessMatch Match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }
        public override string ToString()
        {
            return "K";
        }
        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

        private bool RookCastlingTest(Position pos)
        {
            Piece p = Board.piece(pos);
            return p != null && p is Rook && p.Color == Color && p.MovQuantity == 0;
        }
        public override bool[,] ValidMovements()
        {
            bool[,] validMovement = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            // North
            pos.SetValues(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                validMovement[pos.Line, pos.Column] = true;
            }

            // Northeast
            pos.SetValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                validMovement[pos.Line, pos.Column] = true;
            }

            // East
            pos.SetValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                validMovement[pos.Line, pos.Column] = true;
            }

            // Southeast
            pos.SetValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                validMovement[pos.Line, pos.Column] = true;
            }

            // South
            pos.SetValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                validMovement[pos.Line, pos.Column] = true;
            }

            // Southwest
            pos.SetValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                validMovement[pos.Line, pos.Column] = true;
            }

            // West
            pos.SetValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                validMovement[pos.Line, pos.Column] = true;
            }

            // Northwest
            pos.SetValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                validMovement[pos.Line, pos.Column] = true;
            }

            // Especial Move Castling
            if(MovQuantity == 0 && !Match.Check)
            {
                // Short Castling
                Position posR1 = new Position(pos.Line, pos.Column + 3);
                if (RookCastlingTest(posR1))
                {
                    Position p1 = new Position (pos.Line, pos.Column + 1);
                    Position p2 = new Position (pos.Line, pos.Column + 2);
                    if (Board.piece(p1) == null && Board.piece(p2) == null)
                    {
                        validMovement[pos.Line, pos.Column + 2] = true;
                    }

                }

                // Big Castling
                Position posR2 = new Position(pos.Line, pos.Column -4);
                if (RookCastlingTest(posR2))
                {
                    Position p1 = new Position(pos.Line, pos.Column - 1);
                    Position p2 = new Position(pos.Line, pos.Column - 2);
                    Position p3 = new Position(pos.Line, pos.Column - 3);
                    if (Board.piece(p1) == null && Board.piece(p2) == null && Board.piece(p3) == null)
                    {
                        validMovement[pos.Line, pos.Column - 2] = true;
                    }

                }
            }

            return validMovement;
        }
    }
}
