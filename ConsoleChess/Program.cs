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
            bool checkmate = false;
            string feedback = "";
            Board board = new Board();

            while(!checkmate)
            {
                Console.Clear();
                board.printBoard();

                Console.Write("Select a piece to move.\n");
                Tuple<int, int> originCoordinates = getBoardCoordinateByUserInput();
                Piece selectedPiece = board.boardContents[originCoordinates.Item1, originCoordinates.Item2];                

                if (selectedPiece == null)
                {
                    feedback = "There is no piece there!";
                }
                else //we found a piece at those coordinates
                {
                    Console.WriteLine("\n\nSelected a " + selectedPiece.name + ".");

                    Console.Write("Select a space to move it to.\n");
                    Tuple<int, int> destinationCoordinates = getBoardCoordinateByUserInput();
                    
                    if(destinationCoordinates == null)
                    {
                        feedback = "Those coordinates were invalid.";
                    }
                    else //we can move the piece now
                    {
                        board.boardContents[destinationCoordinates.Item1, destinationCoordinates.Item2] =   //set contents in destination spot
                            board.boardContents[originCoordinates.Item1, originCoordinates.Item2];          //equal to contents in origin spot
                        board.boardContents[originCoordinates.Item1, originCoordinates.Item2] = null;       //then delete contents in origin spot
                    }
                }
            }
        }

        /// <summary>
        ///     Reads a user row/column chessboard input (like 'a4'),
        ///     returns the corresponsing integer pair (like '0,5') 
        /// </summary>
        /// <returns>A Pair (Tuple<int, int> representing a 2-dimensional array index. Null value indicates invalid input.</returns>
        public static Tuple<int, int> getBoardCoordinateByUserInput()
        {
            Dictionary<char, int> columnDisplayNames = new Dictionary<char, int>
            {
                { 'a', 0 },
                { 'b', 1 },
                { 'c', 2 },
                { 'd', 3 },
                { 'e', 4 },
                { 'f', 5 },
                { 'g', 6 },
                { 'h', 7 },
            };

            Console.Write("Column: ");
            char columnInput = Console.ReadKey().KeyChar;

            Console.Write("\n");

            Console.Write("Row: ");
            int rowInput;
            bool isInteger = int.TryParse(Console.ReadKey().KeyChar.ToString(), out rowInput); //stores the value in rowInput if it is an integer

            if (!(columnDisplayNames.ContainsKey(columnInput)) || !(isInteger) || rowInput < 1 || rowInput > 8)
            {
                return null; //invalid entry
            }
            else
            {
                int column = columnDisplayNames[columnInput]; //convert letter to column index
                int row = 8 - (int)rowInput; //convert number to row index
                return new Tuple<int, int>(row, column);
            }
        }
    }
}
