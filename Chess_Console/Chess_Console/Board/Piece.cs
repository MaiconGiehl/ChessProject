namespace board
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovQuantity { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Position position, Color color, int movQuantity)
        {
            Position = position;
            Color = color;
            MovQuantity = movQuantity;
        }
    }
}
