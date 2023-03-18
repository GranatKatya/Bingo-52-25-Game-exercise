using Application;
using Bingo_52_25_Game_exercise.Interface;
using Bingo_52_25_Game_exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_52_25_Game_exercise.BusinessLogic
{
    internal class Game
    {
        private Board board;
        private IBoardChecker boardChecker;
        private readonly int boardSize = 25;
        public Game()
        {
            board = Boardfactory.GenerateBoard(boardSize); 
            boardChecker = new BoardChecker(board);
        }

        // We don't need duplicates
        List<int> passedNumbers = new List<int>();
        private int GenerateNextNumber()
        {
            Random rnd = new Random();
            do
            {
                int nextNumber = rnd.Next(1, 53);
                if (!passedNumbers.Contains(nextNumber))
                {
                    passedNumbers.Add(nextNumber);
                    return nextNumber;
                }
            }
            while (passedNumbers.Count != 52);

            return -1;
        }

        private bool FindNumber(int numberToCheck)
        {
            foreach (Cell cell in board.Matrix) {
                if (cell.Digit == numberToCheck) {
                    cell.IsMarked = true;
                    return true;
                }
            }
            return false;
        }

        private bool CheckBingo() 
        {
            // Check vertical, horizontal and diagonal line
            if (boardChecker.CheckVerticalLine() || boardChecker.CheckHorizontalLine() || boardChecker.CheckDiagonalLine())
            {
                return true;
            }
            return false;
        }

        public void RunGame() {
            Console.WriteLine("Game started.");
            Console.WriteLine("Board generated!");
            board.PrintBoard();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Press space or any key to show next number");
                Console.ReadKey(true);

                // Generate next number
                int nextNumber = GenerateNextNumber();
                if (nextNumber == -1)
                {
                    Console.WriteLine("Game Over!");
                    break;
                }
                Console.WriteLine($"Next number: {nextNumber}");

                // Check if number is in the board
                if (FindNumber(nextNumber))
                {
                    // Reprint the board
                    board.PrintBoard();
                }

                // Do you win?
                if (CheckBingo())
                {
                    Console.WriteLine();
                    Console.WriteLine("-----BINGO------");
                    Console.WriteLine("You win!");
                    break;
                }
            }
        }
    }
}
