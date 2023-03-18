using Application;
using Bingo_52_25_Game_exercise.Interface;
using Bingo_52_25_Game_exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_52_25_Game_exercise.BusinessLogic
{
    internal class BoardChecker: IBoardChecker
    {
        private Board _board;
        public BoardChecker(Board board)
        {
            _board = board;

        }
        public bool CheckHorizontalLine()
        {
            for (int i = 0; i < 5; i++)
            {
                var fiveitems = _board.Matrix.Skip(i * 5).Take(5);
                var allValid = IsAllMarked(fiveitems);
                if (allValid)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckVerticalLine()
        {
            for (int i = 0; i < 5; i++)
            {
                var fiveitems = _board.Matrix.Skip(i).Where((x, i) => i % 5 == 0);
                var allValid = IsAllMarked(fiveitems);
                if (allValid)
                {
                     return true;
                }
            }
            return false;
        }

        public bool CheckDiagonalLine()
        {
            var rightDiagonal = _board.Matrix.Where((x, i) => i % 6 == 0);
            var leftDiagonal = _board.Matrix.Where((x, i) => (i > 3 && i < 21) && (i % 4 == 0));

            return IsAllMarked(rightDiagonal) || IsAllMarked(leftDiagonal);
        }

        private bool IsAllMarked(IEnumerable<Cell> itemsToCheck) 
        {
            var allValid = itemsToCheck.Any() && itemsToCheck.All(item => item.IsMarked);
            if (allValid)
            {
                return true;
            }
            return false;
        }
    }
}
