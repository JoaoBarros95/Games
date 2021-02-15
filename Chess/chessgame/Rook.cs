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
    }
}
