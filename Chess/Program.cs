﻿using System;
using Chess.board;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Screen.printBoard(board);
            Console.ReadLine();
        }
    }
}
