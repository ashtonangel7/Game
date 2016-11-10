﻿namespace Game.Tasks
{
    using Common.DataFlows.Game;
    using Common.Records;

    public class GetNewGameTask
    {
        private readonly NumbersGameDataFlow _numbersGameDataFlow;

        public GetNewGameTask(NumbersGameDataFlow numbersGameDataFlow)
        {
            _numbersGameDataFlow = numbersGameDataFlow;
        }

        internal bool Run(ref NumbersGame newNumbersGame)
        {
            //Get Game Parameters
            if(!_numbersGameDataFlow.ExecuteDataFlowReader())
            {
                return false;
            }

            newNumbersGame = new NumbersGame(999, 10, 5);
            newNumbersGame.SetupNewGame();
            return true;
        }
    }
}
