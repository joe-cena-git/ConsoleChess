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

        public override bool isLegalMove(Tuple<int, int> origin, Tuple<int, int> destination, bool capturing)
        {
            //if the piece has moved along the x axis, it cannot move along the y axis
            if (Math.Abs(destination.Item1 - origin.Item1) > 0 && Math.Abs(destination.Item2 - origin.Item2) != 0)
            {
                return false;
            }

            //if the piece has moved along the y axis, it cannot move along the x axis
            if (Math.Abs(destination.Item1 - origin.Item1) != 0 && Math.Abs(destination.Item2 - origin.Item2) > 0)
            {
                return false;
            }

            return true;
        }
    }
}
