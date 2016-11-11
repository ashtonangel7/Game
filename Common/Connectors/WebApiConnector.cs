namespace Common.Connectors
{
    using System;
    using System.Net.Http;
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

        public bool DoGet<T>(out T responseObject, out string message)
        {
            Task<T> responseTask = DoAsyncGet<T>(_baseAddress);

            try
            {
                responseTask.Wait();
            }
            catch(Exception ex)
            {
                message = string.Format("Error encountered while making a Get request to {0} , Error = {1} - {2}",
                    _baseAddress, ex.Message, ex.StackTrace);
                responseObject = default(T);
                return false;
            }

            responseObject = responseTask.Result;
            message = string.Empty;
            return true;
        }

        private static async Task<T> DoAsyncGet<T>(string baseAddress)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(baseAddress);
            T readRecord = default(T);

            if (responseMessage.IsSuccessStatusCode)
            {
                readRecord = await responseMessage.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new Exception("The Get Request failed with a status code of : " + responseMessage.StatusCode +
                    " to " + baseAddress + " with a reason of " + responseMessage.ReasonPhrase ?? "No reason supplied by server.");
            }

            return readRecord;
        }

        internal bool DoPost<T,R>(T writeObject, string parameters, out R responseRecord, out string message)
        {
            string fullUri = _baseAddress + parameters;

            Task<R> responseTask = DoAsyncPost<T,R>(fullUri, writeObject);

            try
            {
                responseTask.Wait();
            }
            catch (Exception ex)
            {
                message = string.Format("Error encountered while making a Post request to {0} , Error = {1} - {2}",
                    fullUri, ex.Message, ex.StackTrace);
                responseRecord = default(R);
                return false;
            }


            responseRecord = responseTask.Result;
            message = string.Empty;
            return true;
        }

        private static async Task<R> DoAsyncPost<T,R>(string baseAddress, T writeObject)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(baseAddress, writeObject);
            responseMessage.EnsureSuccessStatusCode();

            R responseObject = await responseMessage.Content.ReadAsAsync<R>();
            return responseObject;
        }       
    }
}
