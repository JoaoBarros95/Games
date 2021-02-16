using System;
using System.Collections.Generic;
using System.Text;
using Chess.board;

namespace Chess.chessgame
{
    class King : Piece
    {
        public King (Board chessboard, Color color) : base(chessboard, color)      {}

        public override string ToString()
        {
            return "K";
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
            return mat;
        }
    }
}
