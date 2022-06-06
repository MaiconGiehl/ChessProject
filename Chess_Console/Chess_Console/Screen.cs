using System;
using board;
using Chess;

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
                    PiecePrint(board.piece(l, c));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void BoardPrint(Board board, bool[,] possiblePositions)
        {
            ConsoleColor normalBgColor = Console.BackgroundColor;
            ConsoleColor modifiedBgColor = ConsoleColor.DarkGray;
            for (int l = 0; l < board.Lines; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < board.Columns; c++)
                {
                    if(possiblePositions[l, c])
                    {
                        Console.BackgroundColor = modifiedBgColor;
                    }
                    else
                    {
                        Console.BackgroundColor = normalBgColor;
                    }
                    PiecePrint(board.piece(l, c));
                    Console.BackgroundColor = normalBgColor;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = normalBgColor;
        }


        public static ChessPosition ReadPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);

        }
        public static void PiecePrint(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
