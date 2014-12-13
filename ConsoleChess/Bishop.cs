using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Bishop : Piece
    {
        public Bishop(bool isBlack) : base(isBlack)
        {
            this.appearance = 'b';
        }
    }
}
