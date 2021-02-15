using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int manyMovements { get; protected set; }
        public Board chessboard { get; protected set; }

        public Piece(Position position, Color color, Board chessboard)
        {
            this.position = position;
            this.color = color;
            this.chessboard = chessboard;
            this.manyMovements = 0;
        }
    }
}
