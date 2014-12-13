using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class King : Piece
    {
        public King(bool isBlack) : base(isBlack)
        {
            this.appearance = '$';
        }
    }
}
