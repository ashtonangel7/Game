using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBehaviour gameBehaviour = new GameBehaviour();

            string message;

            if (!gameBehaviour.PlayNewGame(out message))
            {
                Console.WriteLine("Error in PlayNewGame : "+ message);
            }

            Console.WriteLine(message);
        }
    }
}
