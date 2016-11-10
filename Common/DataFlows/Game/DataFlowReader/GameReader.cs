namespace Common.DataFlows.Game.DataFlowReader
{
    using Connectors;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GameReader
    {
        private readonly WebApiConnector _webApiConnector;

        public GameReader(string gameUri, int timeoutMilliseconds)
        {
            _webApiConnector = new WebApiConnector(gameUri, timeoutMilliseconds);
        }

        internal bool ExecuteReader()
        {
            if (!_webApiConnector.DoGet())
            {
                return false;
            }

            return true;
        }


    }
}
