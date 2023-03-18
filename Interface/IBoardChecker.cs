using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_52_25_Game_exercise.Interface
{
    internal interface IBoardChecker
    {
        public bool CheckHorizontalLine();
        public bool CheckVerticalLine();
        public bool CheckDiagonalLine();
    }
}
