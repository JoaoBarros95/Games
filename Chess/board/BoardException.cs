using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.board
{
    class BoardException : Exception
    {
        public BoardException(string msg) : base(msg) { }
    }
}
