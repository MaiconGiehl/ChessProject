using System;
using board;

namespace Chess_Console
{
    internal class Screen
    {
        public static void BoardPrint(Board board)
        {
            for (int l = 0; l < board.Lines; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < board.Columns; c++)
                {
                    if (board.piece(l, c) == null)
                    {
                        Console.Write("- ");

                    }
                    else
                    {
                        PutPice(board.piece(l, c));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PutPice (Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
