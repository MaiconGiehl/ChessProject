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

        public abstract bool[,] ValidMovements();
    }
}
