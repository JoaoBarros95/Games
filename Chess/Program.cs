using System;
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
                    Console.Clear();
                    Screen.printBoard(match.chessboard);

                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPosition().toPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    match.playMove(origin, destiny);
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
