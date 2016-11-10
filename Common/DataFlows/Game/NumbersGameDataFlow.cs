namespace Common.DataFlows.Game
{
    using Connectors;
    using DataFlowReader;
    using System;
    public class NumbersGameDataFlow
    {
        private readonly GameReader _gameReader;

        public NumbersGameDataFlow(string gameUri, int timeoutMilliseconds)
        {
            _gameReader = new GameReader(gameUri, timeoutMilliseconds);
        }

        public bool ExecuteDataFlowReader()
        {
            if (!_gameReader.ExecuteReader())
            {
                return false;
            }

            return true;
        }

        public bool ExecuteDataFlowWriter()
        {
            return true;
        }
    }
}
