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
    }
}
