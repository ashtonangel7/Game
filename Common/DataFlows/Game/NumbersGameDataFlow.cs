namespace Common.DataFlows.Game
{
    using DataFlowReader;
    using DataFlowWriter;
    using Records;
    using Records.DataFlows.DataFlowReadRecord;
    using Records.DataFlows.DataFlowWriteRecord;

    public class NumbersGameDataFlow
    {
        private readonly GameReader _gameReader;
        private readonly GameWriter _gameWriter;

        public NumbersGameDataFlow(string gameUri, int timeoutMilliseconds)
        {
            _gameReader = new GameReader(gameUri, timeoutMilliseconds);
            _gameWriter = new GameWriter(gameUri, timeoutMilliseconds);
        }

        public bool ExecuteDataFlowReader(out NumbersGameReadRecord numbersGameReadRecord, out string message)
        {
            if (!_gameReader.ExecuteReader(out numbersGameReadRecord, out message))
            {
                return false;
            }

            return true;
        }

        public bool ExecuteDataFlowWriter(NumbersGame numbersGame, 
            out NumbersGameWriteResponseRecord responseRecord,
            out string message)
        {
            if (!_gameWriter.ExecuteWriter(numbersGame, out responseRecord, out message))
            {
                return false;
            }

            return true;
        }
    }
}
