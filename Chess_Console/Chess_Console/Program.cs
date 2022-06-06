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
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.WriteLine();
                    Screen.BoardPrint(match.board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadPosition().ToPosition();

                    bool[,] possiblePositions = match.board.piece(origin).ValidMovements();

                    Console.Clear();
                    Screen.BoardPrint(match.board, possiblePositions);

                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadPosition().ToPosition();
                    match.DoMovement(origin, destiny);
                }


            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}