namespace Common.DataFlows.Game.DataFlowWriter
{
    using Connectors;
    using Records;
    using Records.DataFlows.DataFlowWriteRecord;

    public class GameWriter
    {
        private readonly WebApiConnector _webApiConnector;

        public GameWriter(string gameUri, int timeoutMilliseconds)
        {
            _webApiConnector = new WebApiConnector(gameUri, timeoutMilliseconds);
        }

        internal bool ExecuteWriter(NumbersGame numbersGame, 
            out NumbersGameWriteResponseRecord responseRecord,
            out string message)
        {

            NumbersGameWriteRecord numbersGameWriteRecord = new NumbersGameWriteRecord()
            {
                id = numbersGame.GameId,
                last_child = numbersGame.Winner,
                order_of_elimination = numbersGame.ChildrenEliminated.ToArray()
            };

            string parameters = "/" + numbersGame.GameId;

            if (!_webApiConnector.DoPost<NumbersGameWriteRecord, NumbersGameWriteResponseRecord>(numbersGameWriteRecord,
                parameters,
                out responseRecord,
                out message))
            {
                return false;
            }

            return true;
        }
    }
}
