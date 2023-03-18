using System;

namespace Bingo_52_25_Game_exercise.Models
{
    internal class Cell
	{
		public int Digit { get; set; }
		public bool IsMarked { get; set; } = false;
		public void MarkSell() { IsMarked = true; }
	}
}

