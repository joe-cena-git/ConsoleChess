using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            char play = 'y';

            while(play != 'n')
            {
                Board board = new Board();
                board.printBoard();

                play = Console.ReadKey().KeyChar;
            }
        }
    }
}
