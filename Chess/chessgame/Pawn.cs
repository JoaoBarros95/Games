using System;
using System.Collections.Generic;
using System.Text;
using Chess.board;

namespace Chess.chessgame
{
    class Pawn : Piece
    {
        ChessMatch match;

        public Pawn(Board chessboard, Color color, ChessMatch match) : base(chessboard, color) { this.match = match; }

        public override string ToString()
        {
            return "P";
        }

        private bool opposingPiece(Position pos)
        {
            Piece p = chessboard.piece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos)
        {
            return chessboard.piece(pos) == null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[chessboard.lines, chessboard.columns];

            Position pos = new Position(0, 0);

            
            if (color == Color.Black)
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
                //En Passant
                if (position.line == 3)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (chessboard.validPosition(left) && opposingPiece(left) && chessboard.piece(left) == match.vulnerableToPassant)
                    {
                        mat[left.line - 1, left.column] = true;
                    }
                }

                if (position.line == 3)
                {
                    Position right = new Position(position.line, position.column - 1);
                    if (chessboard.validPosition(right) && opposingPiece(right) && chessboard.piece(right) == match.vulnerableToPassant)
                    {
                        mat[right.line - 1, right.column] = true;
                    }
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
                //En Passant
                if (position.line == 4)
                {
                    Position left = new Position(position.line, position.column + 1);
                    if (chessboard.validPosition(left) && opposingPiece(left) && chessboard.piece(left) == match.vulnerableToPassant)
                    {
                        mat[left.line + 1, left.column] = true;
                    }
                }

                if (position.line == 4)
                {
                    Position right = new Position(position.line, position.column + 1);
                    if (chessboard.validPosition(right) && opposingPiece(right) && chessboard.piece(right) == match.vulnerableToPassant)
                    {
                        mat[right.line + 1, right.column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
