using Bingo_52_25_Game_exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_52_25_Game_exercise
{
    internal class Boardfactory
    {
        public static Board GenerateBoard(int boardSize)
        {
            Board board = new Board();
            Random rnd = new Random();
            // We don't need duplicates
            List<int> passedNumbers = new List<int>();
            // for (int i = 0; i < boardSize; i++)
            do
            {
                int nextNumber = rnd.Next(1, 53);
                if (!passedNumbers.Contains(nextNumber))
                {
                    passedNumbers.Add(nextNumber);
                    Cell cell = new Cell { Digit = nextNumber };
                    board.Matrix.Add(cell);
                }
            }
            while (passedNumbers.Count != 25);
            return board;
        }
    }
}
