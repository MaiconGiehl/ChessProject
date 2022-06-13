using board;

namespace Chess
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
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

            return validMovement;
        }
    }
}
