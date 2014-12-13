using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    public class Piece
    {
        public bool isBlack;
        public char appearance = ' ';
        public Piece(bool isBlack)
        {
            this.isBlack = isBlack;
        }
    }
}
