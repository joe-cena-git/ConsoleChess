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
            bool isBlacksTurn = false;
            var legalMove = false;

            //set presentation window size
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(46, 50);

            while(!checkmate)
            {
                Console.Clear();
                board.printBoard();
                if (isBlacksTurn)
                {
                    Console.WriteLine("\nBLACKS TURN ");
                }
                else
                {
                    Console.WriteLine("\nWHITES TURN");
                }
                Console.WriteLine(feedback);

                Console.Write("Select a piece to move.\n");
                
                Tuple<int, int> originCoordinates = getBoardCoordinateByUserInput();

                if(originCoordinates == null)
                {
                    feedback = "Invalid input. Try again.";
                }
                else
                {
                    Piece selectedPiece = board.boardContents[originCoordinates.Item1, originCoordinates.Item2];
                    if (selectedPiece == null)
                    {
                        feedback = "There is no piece there!";
                    }
                    else //we found a piece at those coordinates
                    {
                        if (selectedPiece.isBlack != isBlacksTurn) //elegant way to check turn and piece ownership!
                        {
                            feedback = "That piece does not belong to you.";
                        }
                        else
                        {
                            Console.WriteLine("\n\nSelected a " + selectedPiece.name + ".");

                            Console.Write("Select a space to move it to.\n");
                            Tuple<int, int> destinationCoordinates = getBoardCoordinateByUserInput();

                            if (destinationCoordinates == null)
                            {
                                feedback = "Those coordinates were invalid.";
                            }
                            else //both coordinates are valid
                            {
                                //find out what is in the destination spot
                                var targetPiece = board.boardContents[destinationCoordinates.Item1, destinationCoordinates.Item2];

                                if (targetPiece != null)
                                {
                                    //if it's a friendly piece, we can't move there
                                    if (targetPiece.isBlack == isBlacksTurn) //will return true if we are trying to capture our own piece
                                    {
                                        legalMove = false;
                                    }
                                    else
                                    {
                                        //if it's an enemy piece, we are attempting to capture a piece
                                        legalMove = selectedPiece.isLegalMove(originCoordinates, destinationCoordinates, true);
                                    }
                                }
                                else
                                {
                                    //if there is no piece, we are not capturing
                                    legalMove = selectedPiece.isLegalMove(originCoordinates, destinationCoordinates, false);
                                }

                                if (legalMove == false)
                                {
                                    feedback = "That is not a legal move.";
                                }
                                else
                                {
                                    if((selectedPiece.name == "Queen" || selectedPiece.name == "Bishop" || selectedPiece.name == "Rook") && !board.hasLineOfSight(originCoordinates, destinationCoordinates))
                                    {
                                            feedback = "You do not have line-of-sight to that piece.";
                                    }
                                    else
                                    {
                                        board.boardContents[destinationCoordinates.Item1, destinationCoordinates.Item2] =   //set contents in destination spot
                                        board.boardContents[originCoordinates.Item1, originCoordinates.Item2];          //equal to contents in origin spot
                                        board.boardContents[originCoordinates.Item1, originCoordinates.Item2] = null;       //then delete contents in origin spot
                                        isBlacksTurn = !isBlacksTurn; //it is the other side's turn now, since we moved
                                        feedback = ""; //reset the feedback so we don't show any outdated error messages
                                    }
                                }
                            }
                        }
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
            try
            {
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
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
