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
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            chessboard = new Board(8, 8);
            round = 1;
            currentPlayer = Color.White;
            finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public void playMove(Position origin, Position destiny)
        {
            Piece p = chessboard.removePiece(origin);
            p.Movements();
            Piece capturedPiece = chessboard.removePiece(destiny);
            chessboard.putPiece(p, destiny);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
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
                throw new BoardException("The piece can not be moved to that destination!");
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

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            chessboard.putPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        public void putPieces()
        {
            putNewPiece('e', 1, new King(chessboard, Color.Black));
            putNewPiece('a', 1, new Rook(chessboard, Color.Black));
            putNewPiece('h', 1, new Rook(chessboard, Color.Black));

            putNewPiece('d', 8, new King(chessboard, Color.White));
            putNewPiece('a', 8, new Rook(chessboard, Color.White));
            putNewPiece('h', 8, new Rook(chessboard, Color.White));
        }
    }
}
