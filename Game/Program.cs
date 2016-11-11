namespace Game
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            GameBehaviourWorkflow gameBehaviourWorkFlow;

            try
            {
                gameBehaviourWorkFlow = new GameBehaviourWorkflow();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error setting up Game Behaviour Workflow. Message = " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    Console.WriteLine(ex.InnerException.StackTrace);
                }
                return;
            }

            string message;

            //Catch an unhandled exception.
            try
            {
                if (!gameBehaviourWorkFlow.PlayNewGame(out message))
                {
                    Console.WriteLine("Error in PlayNewGame : " + message);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unhandled Exception in Game Behaviour Workflow. Message = " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    Console.WriteLine(ex.InnerException.StackTrace);
                }
                return;
            }

            Console.WriteLine(message);
        }
    }
}
