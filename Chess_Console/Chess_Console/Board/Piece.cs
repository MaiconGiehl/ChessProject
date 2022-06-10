namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovQuantity { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            MovQuantity = 0;
        }

        public void IncreaseMovQty()
        {
            MovQuantity++;
        }

        public bool DoMovesExist ()
        {
            bool[,] mat = ValidMovements();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo (Position pos)
        {
            return ValidMovements()[pos.Line, pos.Column];
        }
        public abstract bool[,] ValidMovements();
    }
}
