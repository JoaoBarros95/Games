using System;
using System.Collections.Generic;
using System.Text;
using Chess.board;

namespace Chess.chessgame
{
    class Pawn : Piece
    {
        public Pawn(Board chessboard, Color color) : base(chessboard, color) { }

        public override string ToString()
        {
            return "P";
        }

        private bool canMove(Position pos)
        {
            Piece p = chessboard.piece(pos);
            return p == null || p.color != color;
        }

        private bool opposingPiece(Position pos)
        {
            Piece p = chessboard.piece(pos);
            return chessboard != null && p.color != color;
        }

        private bool free(Position pos)
        {
            return chessboard.piece(pos) == null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[chessboard.lines, chessboard.columns];

            Position pos = new Position(0, 0);

            
            if (color == Color.White)
            {
                pos.setValue(position.line - 1, position.column);
                if (chessboard.validPosition(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValue(position.line - 2, position.column);
                if (chessboard.validPosition(pos) && free(pos) && manyMovements == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValue(position.line - 1, position.column + 1);
                if (chessboard.validPosition(pos) && opposingPiece(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValue(position.line - 1, position.column - 1);
                if(chessboard.validPosition(pos) && opposingPiece(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            else
            {
                pos.setValue(position.line + 1, position.column);
                if (chessboard.validPosition(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValue(position.line + 2, position.column);
                if (chessboard.validPosition(pos) && free(pos) && manyMovements == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValue(position.line + 1, position.column + 1);
                if (chessboard.validPosition(pos) && opposingPiece(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.setValue(position.line + 1, position.column - 1);
                if (chessboard.validPosition(pos) && opposingPiece(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            return mat;
        }
    }
}
