namespace Game.Tasks
{
    using Common.Records;

    public class PlayGameTask
    {
        internal bool Run(ref NumbersGame newNumbersGame, out string message)
        {
            if (newNumbersGame == null)
            {
                message = "No valid game object passed into PlayGameTask step.";
                return false;
            }

            if (!newNumbersGame.Play(out message))
            {
                message = "Error in Play Game Task Step : " + message;
                return false;
            }

            message = string.Empty;
            return true; 
        }
    }
}
