using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Queen : Piece
    {
        public Queen(bool isBlack) : base(isBlack)
        {
            this.appearance = 'Q';
        }
    }
}
