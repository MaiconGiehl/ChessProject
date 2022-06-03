using System;
using board;
using Chess;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PutPiece(new Rook(board, Color.Black), new Position(0, 7));
                board.PutPiece(new King(board, Color.Black), new Position(0, 2));

                board.PutPiece(new Rook(board, Color.White), new Position(3, 5));

                Screen.BoardPrint(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}