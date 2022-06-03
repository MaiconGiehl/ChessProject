using System;
using board;
using Chess;

namespace Chess_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition pos = new ChessPosition('c', 7);


            Console.WriteLine(pos);

            Console.WriteLine(pos.ToPosition());

            Console.WriteLine();
        }
    }
}