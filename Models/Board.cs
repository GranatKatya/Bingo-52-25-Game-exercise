using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_52_25_Game_exercise.Models
{
    internal class Board
    {
        public List<Cell> Matrix { get; set; }
        public Board()
        {
            Matrix = new List<Cell>();
        }

        public void PrintBoard()
        {
            int count = 0;
            foreach (var cell in Matrix)
            {
                if (count % 5 == 0)
                {
                    Console.WriteLine();
                }
                if (cell.IsMarked)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\t{cell.Digit}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write($"\t{cell.Digit}");
                }
                count++;
            }
        }
    }
}
