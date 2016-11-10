namespace Game.Tasks
{
    using Common.Records;

    public class PlayGameTask
    {
        internal bool Run(ref NumbersGame newNumbersGame)
        {
            if (!newNumbersGame.Play())
            {
                return false;
            }
            return true; 
        }
    }
}
