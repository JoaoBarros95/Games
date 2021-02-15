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
                Board board = new Board(8, 8);
                board.putPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.putPiece(new King(board, Color.Black), new Position(0, 7));

                Screen.printBoard(board);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.ReadLine();
        }
    }
}
