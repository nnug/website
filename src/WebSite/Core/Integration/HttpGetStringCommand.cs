namespace NNUG.WebSite.Core.Integration
{
    public class HttpGetStringCommand : IHttpGetStringCommand
    {
        private readonly HttpClient _httpClient;

        public HttpGetStringCommand(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<string> InvokeAsync(Uri requestUri)
        {
            return _httpClient.GetStringAsync(requestUri);
        }
    }
}
