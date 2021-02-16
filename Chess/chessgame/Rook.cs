using System;
using System.Collections.Generic;
using System.Text;
using Chess.board;

namespace Chess.chessgame
{
    class Rook : Piece
    {
        public Rook(Board chessboard, Color color) : base(chessboard, color) { }

        public override string ToString()
        {
            return "R";
        }
        private bool canMove(Position pos)
        {
            Piece p = chessboard.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[chessboard.lines, chessboard.columns];

            Position pos = new Position(0, 0);

            //Up
            pos.setValue(position.line - 1, position.column);
            while (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (chessboard.piece(pos) != null && chessboard.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line - 1;
            }

            //Right
            pos.setValue(position.line, position.column + 1);
            while (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (chessboard.piece(pos) != null && chessboard.piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }

            //Down
            pos.setValue(position.line + 1, position.column);
            while (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (chessboard.piece(pos) != null && chessboard.piece(pos).color != color)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }

            //Left
            pos.setValue(position.line, position.column - 1);
            while (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (chessboard.piece(pos) != null && chessboard.piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }

            return mat;
        }
    }
}
