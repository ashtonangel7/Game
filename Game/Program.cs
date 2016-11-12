namespace Game
{
    using System;
    class Program
    {
        /// <summary>
        /// Main entry point, to run the GameBehaviourWorkflow.
        /// Note: just using a console app here to demonstrate the principle.
        /// TODO: We could implement a common logging dataflow to email slack etc..
        /// </summary>
        static void Main()
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
