using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NNUG.WebSite.Core.Integration
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