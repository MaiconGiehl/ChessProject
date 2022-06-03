﻿using System;
using board;


namespace Chess_Console
{
    internal class Screen
    {
        public static void BoardPrint(Board board)
        {
            for (int l = 0; l < board.Lines; l++)
            {

                for (int c = 0; c < board.Columns; c++)
                {
                    if (board.piece(l, c) == null)
                    {
                        Console.Write("- ");

                    }
                    else
                    {
                        Console.Write(board.piece(l, c) + "-");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}