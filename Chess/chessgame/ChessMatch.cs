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
        public bool check { get; private set; }

        public ChessMatch()
        {
            chessboard = new Board(8, 8);
            round = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieces();
        }

        public Piece playMove(Position origin, Position destiny)
        {
            Piece p = chessboard.removePiece(origin);
            p.Movements();
            Piece capturedPiece = chessboard.removePiece(destiny);
            chessboard.putPiece(p, destiny);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMove(Position origin, Position destiny, Piece capturedpiece)
        {
            Piece p = chessboard.removePiece(destiny);
            p.undoMovements();
            if (capturedpiece != null)
            {
                chessboard.putPiece(capturedpiece, destiny);
                captured.Remove(capturedpiece);
            }
            chessboard.putPiece(p, origin);
        }

        public void performMove(Position origin, Position destiny)
        {
            Piece capturedPiece = playMove(origin, destiny);
            if (inCheck(currentPlayer))
            {
                undoMove(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check");
            }
            if (inCheck(opponent(currentPlayer))) { check = true; }

            if (testCheckmate(opponent(currentPlayer))) { finished = true; }
            else
            {
                round++;
                changePlayer();
            }
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

        private Color opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king (Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }      

        public bool testCheckmate(Color color)
        {
            if (!inCheck(color)) { return false; }

            foreach(Piece p in piecesInGame(color))
            {
                bool[,] mat = p.possibleMoves();
                for (int i = 0; i < chessboard.lines; i++)
                {
                    for (int j = 0; j < chessboard.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = p.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = playMove(origin, destiny);
                            bool testCheck = inCheck(color);
                            undoMove(origin, destiny, capturedPiece);
                            if (!testCheck) { return false; }
                        }
                    }
                }
            }
            return true;
        }
        
        public bool inCheck (Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException("Game over");
            }
            foreach (Piece x in piecesInGame(opponent(color)))
            {
                bool[,]  mat= x.possibleMoves();
                if (mat[K.position.line, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public void putNewPiece(char column, int line, Piece piece)
        {
            chessboard.putPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        public void putPieces()
        {
            putNewPiece('e', 1, new King(chessboard, Color.Black));
            //putNewPiece('a', 1, new Rook(chessboard, Color.Black));
            //putNewPiece('h', 1, new Rook(chessboard, Color.Black));

            putNewPiece('d', 8, new King(chessboard, Color.White));
            putNewPiece('a', 8, new Rook(chessboard, Color.White));
            putNewPiece('h', 8, new Rook(chessboard, Color.White));
        }
    }
}
