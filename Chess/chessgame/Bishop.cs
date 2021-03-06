﻿using System;
using System.Collections.Generic;
using System.Text;
using Chess.board;

namespace Chess.chessgame
{
    class Bishop : Piece
    {
        public Bishop (Board chessboard, Color color ) : base(chessboard, color) { }

        public override string ToString()
        {
            return "B";
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

            //Up and Right
            pos.setValue(position.line - 1, position.column + 1);
            while (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (chessboard.piece(pos) != null && chessboard.piece(pos).color != color)
                {
                    break;
                }
                pos.setValue(pos.line - 1, pos.column + 1);
            }

            //Right and Down
            pos.setValue(position.line + 1, position.column + 1);
            while (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (chessboard.piece(pos) != null && chessboard.piece(pos).color != color)
                {
                    break;
                }
                pos.setValue(pos.line + 1, pos.column + 1);
            }

            //Down and left
            pos.setValue(position.line + 1, position.column - 1);
            while (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (chessboard.piece(pos) != null && chessboard.piece(pos).color != color)
                {
                    break;
                }
                pos.setValue(pos.line + 1, pos.column - 1);
            }

            //Left and up
            pos.setValue(position.line - 1, position.column - 1);
            while (chessboard.validPosition(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (chessboard.piece(pos) != null && chessboard.piece(pos).color != color)
                {
                    break;
                }
                pos.setValue(pos.line - 1, pos.column - 1);
            }

            return mat;
        }
    }
}
