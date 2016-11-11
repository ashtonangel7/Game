namespace Game
{
    using Common.DataFlows.Game;
    using Common.Records;
    using Tasks;

    public class GameBehaviour
    {
        private readonly NumbersGameDataFlow _numbersGameDataFlow;

        private readonly PlayGameTask _playGameTask;
        private readonly GetNewGameTask _getNewGameTask;
        private readonly WriteGameResultsTask _writeGameResultsTask;

        public GameBehaviour()
        {
            _numbersGameDataFlow = new NumbersGameDataFlow(Settings.Default.GameUri, Settings.Default.WebApiTimeout);

            _getNewGameTask = new GetNewGameTask(_numbersGameDataFlow);
            _playGameTask = new PlayGameTask();
            _writeGameResultsTask = new WriteGameResultsTask(_numbersGameDataFlow);
        }

        public bool PlayNewGame(out string message)
        {
            NumbersGame newNumbersGame = null;

            if (!_getNewGameTask.Run(ref newNumbersGame, out message))
            {
                message = "Error encountered in Game Workflow, getNewGameTask step : " + message;
                return false;
            }

            if (!_playGameTask.Run(ref newNumbersGame, out message))
            {
                message = "Error encountered in Game Workflow, playGameTask step : " + message;
                return false;
            }

            if (!_writeGameResultsTask.Run(ref newNumbersGame, out message))
            {
                message = "Error encountered in Game Workflow, writeGameResultsTask step : " + message;
                return false;
            }

            return true;
        }
       
    }
}
