using Bingo_52_25_Game_exercise.BusinessLogic;
using static System.Net.Mime.MediaTypeNames;

namespace Application
{
    class Program
    {
        public static int boardSize = 25;
        static void Main(string[] args)
        {
            Game game = new Game();
            game.RunGame();
        }
    }
}

      
