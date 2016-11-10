namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBehaviour gameBehaviour = new GameBehaviour();
            if(!gameBehaviour.PlayNewGame())
            {
                //Write Error.
            }
        }
    }
}
