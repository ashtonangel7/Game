namespace Game.Tasks
{
    using Common.DataFlows.Game;
    using Common.Records;
    using Common.Records.DataFlows.DataFlowWriteRecord;
    using System;

    public class WriteGameResultsTask
    {
        private readonly NumbersGameDataFlow _numbersGameDataFlow;

        public WriteGameResultsTask(NumbersGameDataFlow numbersGameDataFlow)
        {
            _numbersGameDataFlow = numbersGameDataFlow;
        }

        internal bool Run(ref NumbersGame newNumbersGame, out string message)
        {
            NumbersGameWriteResponseRecord responseRecord = null;

            if (!_numbersGameDataFlow.ExecuteDataFlowWriter(newNumbersGame, out responseRecord, out message))
            {
                return false;
            }

            message = string.Format("Game {0} finished with a message of : {1}.", responseRecord.id,
                responseRecord.message);

            return true;
        }
    }
}
