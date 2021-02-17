using System;
using System.Collections.Generic;
using System.Text;
using Chess.board;

namespace Chess.chessgame
{
    class King : Piece
    {
        ChessMatch match;

        public King (Board chessboard, Color color, ChessMatch match) : base(chessboard, color)      {  this.match = match; }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece p = chessboard.piece(pos);
            return p == null || p.color != color;
        }

        private bool castlingRook(Position pos)
        {
            Piece p = chessboard.piece(pos);
            return p != null && p is Rook && p.color == color && p.manyMovements == 0;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[chessboard.lines, chessboard.columns];

            Position pos = new Position(0, 0);

            //Up
            pos.setValue(position.line - 1, position.column);
            if (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //Up and right
            pos.setValue(position.line - 1, position.column + 1);
            if (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //Right
            pos.setValue(position.line, position.column + 1);
            if (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //Right and down
            pos.setValue(position.line + 1, position.column + 1);
            if (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //Down
            pos.setValue(position.line + 1, position.column);
            if (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //Down and left
            pos.setValue(position.line + 1, position.column - 1);
            if (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //Left
            pos.setValue(position.line, position.column - 1);
            if (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //Left and up
            pos.setValue(position.line - 1, position.column - 1);
            if (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            //Small Castling
            if (manyMovements == 0  && !match.check)
            {
                Position posR1 = new Position(position.line, position.column + 3);
                if (castlingRook(posR1))
                {
                    Position p1 = new Position(position.line, position.column + 1);
                    Position p2 = new Position(position.line, position.column + 2);
                    if (chessboard.piece(p1) == null && chessboard.piece(p2) == null)
                    {
                        mat[position.line, position.column + 2] = true;
                    }
                }
            }
            //Great Castling
            if (manyMovements == 0 && !match.check)
            {
                Position posR2 = new Position(position.line, position.column - 4);
                if (castlingRook(posR2))
                {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (chessboard.piece(p1) == null && chessboard.piece(p2) == null && chessboard.piece(p3) == null)
                    {
                        mat[position.line, position.column - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
