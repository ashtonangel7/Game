namespace Common.Connectors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class WebApiConnector
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private readonly string _baseAddress;
        private readonly int _timeoutMilliseconds;

        public WebApiConnector(string baseAddress, int timeoutMilliseconds)
        {
            _baseAddress = baseAddress;
            _timeoutMilliseconds = timeoutMilliseconds;
            _httpClient.BaseAddress = new Uri(_baseAddress);
            _httpClient.Timeout = new TimeSpan(0, 0, 0, 0, _timeoutMilliseconds);
        }

        public bool DoGet()
        {
            string result = await DoAsyncGet(_baseAddress);

            return true;
        }

        private static async Task<string> DoAsyncGet(string baseAddress)
        {
            string responseMessage = await _httpClient.GetStringAsync(baseAddress);
            return responseMessage;
        }        
    }
}
