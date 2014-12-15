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
        public char appearance;
        public string name;
        public Piece(bool isBlack)
        {
            this.appearance = ' ';
            this.isBlack = isBlack;
            this.name = this.GetType().Name;
        }

        public virtual bool isLegalMove(Tuple<int, int> origin, Tuple<int,int> destination, bool capturing)
        {
            //RULE: all pieces must stay in the 8x8 play area at all times
            if(destination.Item1 < 0 || destination.Item1 > 7 || destination.Item2 < 0 || destination.Item2 > 7)
            {
                return false;
            }

            //RULE: a piece may not "move" to the same spot it is already in... no skips in chess!
            if(destination.Item1 == origin.Item1 && destination.Item2 == origin.Item2)
            {
                return false;
            }

            return true;
        }
    }
}
