using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int manyMovements { get; protected set; }
        public Board chessboard { get; protected set; }

        public Piece(Board chessboard, Color color )
        {
            this.position = null;
            this.color = color;
            this.chessboard = chessboard;
            this.manyMovements = 0;
        }

        public int Movements()
        {
            return manyMovements++;
        }

        public int undoMovements()
        {
            return manyMovements--;
        }

        public bool possibleExistingMoves()
        {
            bool[,] mat = possibleMoves();
            for (int i = 0; i < chessboard.lines; i++)
            {
                for (int j = 0; j < chessboard.columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos)
        {
            return possibleMoves()[pos.line, pos.column];
        }

        public abstract bool[,] possibleMoves();
    }
}
