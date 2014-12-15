using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Board
    {
        public Piece[,] boardContents { get; set; }
        public Board()
        {
            boardContents = new Piece[8, 8];

            //setup kings
            boardContents[0, 3] = new King(true);
            boardContents[7, 4] = new King(false);

            //setup queens
            boardContents[0, 4] = new Queen(true);
            boardContents[7, 3] = new Queen(false);

            //setup bishops
            boardContents[0, 2] = new Bishop(true);
            boardContents[0, 5] = new Bishop(true);
            boardContents[7, 2] = new Bishop(false);
            boardContents[7, 5] = new Bishop(false);

            //setup knights
            boardContents[0, 1] = new Knight(true);
            boardContents[0, 6] = new Knight(true);
            boardContents[7, 1] = new Knight(false);
            boardContents[7, 6] = new Knight(false);

            //setup rooks
            boardContents[0, 0] = new Rook(true);
            boardContents[0, 7] = new Rook(true);
            boardContents[7, 0] = new Rook(false);
            boardContents[7, 7] = new Rook(false);

            //setup pawns
            for (var p = 0; p < 8; p++)
            {
                boardContents[1, p] = new Pawn(true);
                boardContents[6, p] = new Pawn(false);
            }
                
        }

        public void printBoard()
        {
            Console.WriteLine();
            Console.WriteLine("     A    B    C    D    E    F    G    H");
            Console.WriteLine();
            for (var row = 0; row < 8; row++ )
            {
                
                for (var boxHeight = 0; boxHeight < 3; boxHeight++ )
                {
                    Console.ResetColor();
                    if(boxHeight == 1)
                    {
                        
                        Console.Write(" "+Math.Abs(8-row)+" "); //prints numbers descending from 8 to 1
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    for (var column = 0; column < 8; column++)
                    {
                        if (row % 2 == 0)
                        {
                            if (column % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                            }
                        }
                        else
                        {
                            if (column % 2 != 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                            }
                        }

                        Console.Write("  ");
                        var contents = boardContents[row, column];

                        if (contents != null && boxHeight == 1)
                        {
                            if (contents.isBlack)
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            Console.Write(contents.appearance);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                        Console.Write("  ");
                    }
                    Console.ResetColor();
                    if (boxHeight == 1)
                    {

                        Console.Write(" "+Math.Abs(8 - row)); //prints numbers descending from 8 to 1
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("     A    B    C    D    E    F    G    H");
            Console.WriteLine();
        }

        public bool hasLineOfSight(Tuple<int, int> origin, Tuple<int, int> destination)
        {
            //get slope of line
            double rise = destination.Item1 - origin.Item1;
            double run = destination.Item2 - origin.Item2;
            double slope = rise / run;

            Debug.WriteLine("Line of sight calculation!");
            Debug.WriteLine("Origin: " + origin.Item1 + ", " + origin.Item2);
            Debug.WriteLine("Destination: " + destination.Item1 + ", " + destination.Item2);
            Debug.WriteLine("Slope: " + slope);
            Debug.WriteLine("Rise: " + rise);
            Debug.WriteLine("Run: " + run);

            if(Math.Abs(slope) != 1 && slope != 0 && Math.Abs(slope) != Double.PositiveInfinity) //Slope can only be 1, 0, or infinity (flat or diagonal)
            {
                Debug.WriteLine("Slope is not 1, 0, or infinity. Exiting line of sight calculation");
                return false;
            }
            else
            {
                double y = origin.Item2;
                double x = origin.Item1;
                while (y != destination.Item2 || x != destination.Item1)
                {
                    if(Math.Abs(slope) == 1) //this is a diagonal line in some direction
                    {
                        if (rise > 0)
                        {
                            x += 1;
                        }
                        else
                        {
                            x -= 1;
                        }

                        if(run > 0)
                        {
                            y += 1;
                        }
                        else
                        {
                            y -= 1;
                        }
                    }
                    else if(slope == 0) //this is a horizontal line
                    {
                        if (run > 0)
                        {
                            y += 1;
                        }
                        else
                        {
                            y -= 1;
                        }
                    }
                    else if(Math.Abs(slope) == Double.PositiveInfinity) //this is a vertical line
                    {
                        if (rise > 0)
                        {
                            x += 1;
                        }
                        else
                        {
                            x -= 1;
                        }
                    }
                    
                    Debug.WriteLine("Checked " + x + ", " + y);
                    //along the path to the destination, if there is a piece in the way then this is an invalid move.
                    if(this.boardContents[(int)x, (int)y] != null)
                    {
                        Debug.WriteLine("Found an object!");
                        //if the only thing in the way is a piece at the end, that's fine. We can capture it.
                        if (x != destination.Item1 || y != destination.Item2)
                        {
                            Debug.WriteLine("And it isn't at the destination! No line of sight!");
                            return false;
                        }
                    }
                }
                Debug.WriteLine("Got to destination (" + x + ", " + y + "), had line of sight.");
            }

            

            return true;
        }
    }
}
