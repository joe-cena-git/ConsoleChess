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

            Dictionary<char, int> columnAliases = new Dictionary<char, int>
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

            while(!checkmate)
            {
                Console.Clear();
                board.printBoard();

                Console.WriteLine(feedback);

                Console.Write("Select a column: ");
                char columnInput = Console.ReadKey().KeyChar;

                Console.Write("\n");

                Console.Write("Select a row: ");
                int rowInput;
                bool isInteger = int.TryParse(Console.ReadKey().KeyChar.ToString(), out rowInput); //stores the value in rowInput if it is an integer

                if (!(columnAliases.ContainsKey(columnInput)) || !(isInteger) || rowInput < 1 || rowInput > 8)
                {
                    feedback = "Invalid row/column selection (" + columnInput + rowInput + "). Try again.";
                }
                else
                {
                    int column = columnAliases[columnInput]; //convert letter to column index
                    int row = 8 - (int)rowInput; //convert number to row index
                    
                    Piece selectedPiece = board.boardContents[row, column];

                    if (selectedPiece == null)
                    {
                        feedback = "There is no piece there!";
                    }
                    else
                    {
                        Console.WriteLine("\n\nSelected " + selectedPiece.appearance + " at " + rowInput + columnInput + ".");

                        Console.Write("Move to column: ");
                        char destinationColumnInput = Console.ReadKey().KeyChar;

                        Console.Write("\n");

                        Console.Write("Select a row: ");
                        int destinationRowInput;
                        bool destinationIsInteger = int.TryParse(Console.ReadKey().KeyChar.ToString(), out destinationRowInput); //stores the value in rowInput if it is an integer

                        if (!(columnAliases.ContainsKey(destinationColumnInput)) || !(destinationIsInteger) || destinationRowInput < 1 || destinationRowInput > 8)
                        {
                            //the destination coordinates were invalid
                            feedback = "Invalid row/column selection (" + destinationColumnInput + destinationRowInput + "). Try again.";

                            //TODO: check for move legality here
                        }
                        else //we can move the piece now
                        {
                            int destinationColumn = columnAliases[destinationColumnInput]; //convert letter to column index
                            int destinationRow = 8 - (int)destinationRowInput; //convert number to row index

                            board.boardContents[destinationRow, destinationColumn] = board.boardContents[row, column]; //copy piece from the selected spot to new spot
                            board.boardContents[row, column] = null; //remove the original piece
                        }
                    }
                }
            }
        }
    }
}
