namespace Common.DataFlows.Game.DataFlowReader
{
    using Connectors;
    using Records.DataFlows.DataFlowReadRecord;

    public class GameReader
    {
        private readonly WebApiConnector _webApiConnector;

        public GameReader(string gameUri, int timeoutMilliseconds)
        {
            _webApiConnector = new WebApiConnector(gameUri, timeoutMilliseconds);
        }

        internal bool ExecuteReader(out NumbersGameReadRecord numbersGameReadRecord,out string message)
        {
            if (!_webApiConnector.DoGet<NumbersGameReadRecord>(out numbersGameReadRecord, out message))
            {
                return false;
            }

            return true;
        }


    }
}
