using System;


namespace TicTacToe
{
    /* Tic Tac Toe Sudo Code
     * one method for finding horizontal win
     * one method for finding veritcal win
     * one method for finding diagonal win
     * One method for taking player input
     * One method for making computer move
     * One method for printing out the board
     * One method to control all methods
     * 
     * Player will always be X
     * Computer will always be O
     * 
     * 
     */
    internal class Program
    {
        public static void Main(string[] args)
        {
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.PlayGame();
        }
    }

    public class TicTacToe
    {
        private string[,] board = new string [3,3] { {" ", " ", " "},
                                                     {" ", " ", " "},
                                                     {" ", " ", " "} };
        private string winner = "Computer";

        public void PlayGame()
        {
            Console.WriteLine("Let play Tic Tac Toe!");
            while (!HasWon())
            {
                PrintBoard();
                PlayerMove();
                if (HasWon())
                {
                    winner = "Player";
                    break;
                }
                ComputerMove();
            }
            
            Console.WriteLine($"{winner} won!");
            PrintBoard();
            Console.WriteLine("Thanks for playing Tic Tac Toe!");
        }

        public void PlayerMove()
        {
            bool validMove = false;
            while(!validMove)
            {
                try
                {
                    Console.Write("Enter the X coordinate for your move: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the Y coordinate for your move: ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    if (board[x - 1, y - 1] != " ")
                    {
                        Console.WriteLine($"Coordinates {x},{y} has already been filled.");
                    }
                    else
                    {
                        board[x - 1, y - 1] = "X";
                        validMove = true;
                    }
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("Coordinates entered not valid.");
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Coordinates entered does not exist.");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Something went wrong in PlayerMove(). Error: {ex.Message}");
                    Environment.Exit(1);
                }
            }
            

        }

        public void ComputerMove()
        {
            bool coordinateAvailiable = false;
            Random random = new Random();
            while (!coordinateAvailiable)
            {
                int x = random.Next(0, board.GetLength(0));
                int y = random.Next(0, board.GetLength(1));

                if (board[x, y] == " ")
                {
                    board[x, y] = "O";
                    coordinateAvailiable = true;
                }
            }
        }

        public void PrintBoard()
        {
            Console.WriteLine("-------------");
            for (int i = 0; i < board.GetLength(0); ++i)
            {
                Console.WriteLine($"| {board[i, 0]} | {board[i, 1]} | {board[i, 2]} | ");
                Console.WriteLine("-------------");
            }
        }

        private bool HasWon()
        {
            if (HorizontalWin())
                return true;
            else if(VerticalWin())
                return true;
            else if(DiagonalWin())
                return true;
            else
                return false;
        }

        public bool HorizontalWin()
        {
            for(int i = 0; i < board.GetLength(0); ++i)
            {
                if(board[i,0] != " " && board[i, 0].Equals(board[i,1], StringComparison.OrdinalIgnoreCase) && board[i,0].Equals(board[i,2], StringComparison.OrdinalIgnoreCase))
                {
                    
                    return true;
                }
            }
            return false;
        }

        public bool VerticalWin()
        {
            for(int i = 0; i < board.GetLength(1); ++i)
            {
                if(board[0,i] != " " && board[0,i].Equals(board[1,i], StringComparison.OrdinalIgnoreCase) && board[0,i].Equals(board[2,i], StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool DiagonalWin()
        {
            if(board[0,0] != " " && board[0,0].Equals(board[1,1], StringComparison.OrdinalIgnoreCase) && board[0,0].Equals(board[2,2], StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if(board[0,2] != " " && board[0,2].Equals(board[1,1], StringComparison.OrdinalIgnoreCase) && board[0,2].Equals(board[2,0], StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
