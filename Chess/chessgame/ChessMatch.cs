using System;
using System.Collections.Generic;
using System.Text;
using Chess.board;

namespace Chess.chessgame
{
    class ChessMatch
    {
        public Board chessboard { get; private set; }
        private int round;
        private Color currentPlayer;
        public bool finished { get; private set; }

        public ChessMatch()
        {
            chessboard = new Board(8, 8);
            round = 1;
            currentPlayer = Color.White;
            finished = false;
            putPieces();
        }

        public void playMove(Position origin, Position destiny)
        {
            Piece p = chessboard.removePiece(origin);
            p.Movements();
            Piece capturedPiece = chessboard.removePiece(destiny);
            chessboard.putPiece(p, destiny);
        }

        public void putPieces()
        {            
            chessboard.putPiece(new King(chessboard, Color.Black), new ChessPosition('e', 1).toPosition());
            chessboard.putPiece(new Rook(chessboard, Color.Black), new ChessPosition('a', 1).toPosition());
            chessboard.putPiece(new Rook(chessboard, Color.Black), new ChessPosition('h', 1).toPosition());

            chessboard.putPiece(new King(chessboard, Color.White), new ChessPosition('d', 8).toPosition());
            chessboard.putPiece(new Rook(chessboard, Color.White), new ChessPosition('a', 8).toPosition());
            chessboard.putPiece(new Rook(chessboard, Color.White), new ChessPosition('h', 8).toPosition());
        }
    }
}
