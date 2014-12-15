using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Pawn : Piece
    {
        public Pawn(bool isBlack) : base(isBlack) 
        {
            this.appearance = 'x';
        }

        public override bool isLegalMove(Tuple<int, int> origin, Tuple<int, int> destination, bool capturing)
        {
            //RULE: this piece must follow all base piece rules
            if(base.isLegalMove(origin, destination, capturing) == false)
            {
                Debug.Write("ILLEGAL: Pawn did not follow base piece rules");
                return false;
            }
            
            //RULE: if black, this pawn may only move downward (i didn't mean to do that, i swear)
            if(this.isBlack == true && destination.Item1 < origin.Item1)
            {
                Debug.Write("ILLEGAL: Black pawn moved upward");
                return false;
            }

            //RULE: if white, this pawn may only move upward (again, I apologize)
            if (this.isBlack == false && destination.Item1 > origin.Item1)
            {
                Debug.Write("ILLEGAL: White pawn moved downward");
                return false;
            }

            //RULE: if not capturing, this piece must remain in its own column
            if (destination.Item2 != origin.Item2 && capturing == false)
            {
                Debug.Write("ILLEGAL: Pawn left its column while not capturing");
                return false;
            }

            //RULE: this piece may never move more than 1 column horizontally
            if (Math.Abs(destination.Item2 - origin.Item2) > 1)
            {
                Debug.Write("ILLEGAL: Pawn moved more than 1 column horizontally");
                return false;
            }

            //RULE: this piece may never move more than 2 spaces vertically
            if (Math.Abs(destination.Item1 - origin.Item1) > 2)
            {
                Debug.Write("ILLEGAL: Pawn moved more than 2 spaces vertically");
                return false;
            }

            //RULE: this piece may only move forward two spaces if it is on its original home row
            if (Math.Abs(destination.Item1 - origin.Item1) > 1) //if this piece is moving more than one space vertically
            {
                if (this.isBlack)
                {
                    if (origin.Item1 != 1) //row 1 is where black pawns start
                    {
                        Debug.Write("ILLEGAL: Black pawn tried to move 2 spots, but was not on home row");
                        return false;
                    }
                }
                else
                {
                    if (origin.Item1 != 6) //row 6 is where white pawns start
                    {
                        Debug.Write("ILLEGAL: White pawn tried to move 2 spots, but was not on home row");
                        return false;
                    }
                }
            }
           
            return true;
        }
    }
}
