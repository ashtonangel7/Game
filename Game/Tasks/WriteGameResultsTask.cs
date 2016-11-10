namespace Game.Tasks
{
    using Common.DataFlows.Game;
    using Common.Records;

    public class WriteGameResultsTask
    {
        private readonly NumbersGameDataFlow _numbersGameDataFlow;

        public WriteGameResultsTask(NumbersGameDataFlow numbersGameDataFlow)
        {
            _numbersGameDataFlow = numbersGameDataFlow;
        }

        internal bool Run(ref NumbersGame newNumbersGame)
        {
            if (!_numbersGameDataFlow.ExecuteDataFlowWriter())
            {
                return false;
            }

            return true;
        }
    }
}
