namespace Game.Tasks
{
    using Common.DataFlows.Game;
    using Common.Records;
    using Common.Records.DataFlows.DataFlowReadRecord;
    using System;

    public class GetNewGameTask
    {
        private readonly NumbersGameDataFlow _numbersGameDataFlow;

        public GetNewGameTask(NumbersGameDataFlow numbersGameDataFlow)
        {
            _numbersGameDataFlow = numbersGameDataFlow;
        }

        internal bool Run(ref NumbersGame newNumbersGame, out string message)
        {
            NumbersGameReadRecord numbersGameReadRecord;

            //Get Game Parameters
            if (!_numbersGameDataFlow.ExecuteDataFlowReader(out numbersGameReadRecord, out message))
            {
                return false;
            }

            try
            {
                newNumbersGame = new NumbersGame(numbersGameReadRecord.id,
                    numbersGameReadRecord.children_count, numbersGameReadRecord.eliminate_each);
            }
            catch (ArgumentException ex)
            {
                message = string.Format("Error initializing new game with parameters id : {1} children_count: {2} eliminate_each: {3} Error = {0}",
                    ex.Message, numbersGameReadRecord.id, numbersGameReadRecord.children_count,
                    numbersGameReadRecord.eliminate_each);
                return false;
            }


            newNumbersGame.SetupNewGame();
            return true;
        }
    }
}
