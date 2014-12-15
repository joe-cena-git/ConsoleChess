using System;
using System.Collections.Generic;
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
    }
}
