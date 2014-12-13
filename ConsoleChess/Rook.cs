using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Rook : Piece
    {
        public Rook(bool isBlack) : base(isBlack)
        {
            this.appearance = '#';
        }
    }
}
