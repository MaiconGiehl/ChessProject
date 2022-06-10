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
                    try
                    {
                        Console.Clear();
                        Screen.BoardPrint(match.Board);
                        Console.WriteLine();
                        Console.WriteLine("Shift: " + match.Shift);
                        Console.WriteLine("Waiting for: " + match.CurrentPlayer);

                        Console.WriteLine();

                        Console.Write("Origin: ");
                        Position origin = Screen.ReadPosition().ToPosition();
                        match.OriginValidate(origin);

                        bool[,] possiblePositions = match.Board.piece(origin).ValidMovements();

                        Console.Clear();
                        Screen.BoardPrint(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadPosition().ToPosition();
                        match.DestinyValidate(origin, destiny);

                        match.MakeMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }


            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}