using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NNUG.WebSite.Integration
{
    public class HttpGetStringCommand : IHttpGetStringCommand
    {
        public async Task<string> InvokeAsync(Uri requestUri)
        {
            var httpClient = new HttpClient();
            return await httpClient.GetStringAsync(requestUri);
        }
    }
}