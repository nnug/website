using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NNUG.WebSite.Core.Integration
{
    public class HttpGetStringFromEmbeddedResourceCommand : IHttpGetStringCommand
    {
        public Task<string> InvokeAsync(Uri requestUri)
        {
            var resourceName = requestUri.Segments.Last();
            var queryStringParameters = HttpUtility.ParseQueryString(requestUri.Query);
            var groupUrlName = queryStringParameters["group_urlname"];

            var embeddedResourceName = string.Format("NNUG.WebSite.App_Data_DesignTime.{0}-{1}.json", resourceName, groupUrlName);
            return Task.FromResult(ReadEmbeddedTextFile(embeddedResourceName));
        }

        private string ReadEmbeddedTextFile(string embeddedResourceName)
        {
            using (var stream = GetType().Assembly.GetManifestResourceStream(embeddedResourceName))
            {
                Debug.Assert(stream != null, "stream != null");
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}