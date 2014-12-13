using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Board
    {
        public Piece[,] board;

        public Board()
        {
            board = new Piece[8,8];

            //setup kings
            board[0, 3] = new King(true);
            board[7, 4] = new King(false);

            //setup queens
            board[0, 4] = new Queen(true);
            board[7, 3] = new Queen(false);

            //setup bishops
            board[0, 2] = new Bishop(true);
            board[0, 5] = new Bishop(true);
            board[7, 2] = new Bishop(false);
            board[7, 5] = new Bishop(false);

            //setup knights
            board[0, 1] = new Knight(true);
            board[0, 6] = new Knight(true);
            board[7, 1] = new Knight(false);
            board[7, 6] = new Knight(false);

            //setup rooks
            board[0, 0] = new Rook(true);
            board[0, 7] = new Rook(true);
            board[7, 0] = new Rook(false);
            board[7, 7] = new Rook(false);

            //setup pawns
            for (var p = 0; p < 8; p++)
            {
                board[1, p] = new Pawn(true);
                board[6, p] = new Pawn(false);
            }
                
        }

        public void printBoard()
        {
            Console.WriteLine("   a b c d e f g h ");
            Console.WriteLine("  -----------------");
            for (var row = 0; row < 8; row++ )
            {
                Console.Write(Math.Abs(8-row)+" "); //fancy math to print descending numbers (oooh, aaah)
                for(var column = 0; column < 8; column++)
                {
                    Console.Write("|");
                    var contents = board[row, column];

                    if (contents != null)
                    {
                        Console.Write(contents.appearance);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("|");
                Console.WriteLine("  -----------------");
            }
        }
    }
}
