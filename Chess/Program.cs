﻿using System;
using Chess.board;
using Chess.chessgame;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.printBoard(match.chessboard);
                        Console.WriteLine();
                        Console.WriteLine("Round: " + match.round);
                        Console.WriteLine("Waiting for " + match.currentPlayer + " to play");

                        Console.Write("Origin: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        match.validateOriginPosition(origin);

                        bool[,] possiblePositions = match.chessboard.piece(origin).possibleMoves();
                        Console.Clear();
                        Screen.printBoard(match.chessboard, possiblePositions);

                        Console.Write("Destiny: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        match.validateDestinyPosition(origin, destiny);

                        match.performMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }                
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.ReadLine();
        }
    }
}
