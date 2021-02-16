using System;
using System.Collections.Generic;
using System.Text;
using Chess.board;

namespace Chess.chessgame
{
    class ChessMatch
    {
        public Board chessboard { get; private set; }
        public int round { get; private set; }
        public Color currentPlayer { get; private set; }
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

        public void performMove(Position origin, Position destiny)
        {
            playMove(origin, destiny);
            round++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos)
        {
            if (chessboard.piece(pos) == null)
            {
                throw new BoardException("There are no pieces in the chosen position");
            }
            if (currentPlayer != chessboard.piece(pos).color)
            {
                throw new BoardException("The piece chosen is not yours");
            }
            if (!chessboard.piece(pos).possibleExistingMoves())
            {
                throw new BoardException("There are no possible movements for the chosen piece");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!chessboard.piece(origin).canMoveTo(destiny))
            {
                throw new BoardException("Invalid position!");
            }
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
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
