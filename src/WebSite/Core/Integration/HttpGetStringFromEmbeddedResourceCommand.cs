using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace NNUG.WebSite.Core.Integration
{
    public class HttpGetStringFromEmbeddedResourceCommand : IHttpGetStringCommand
    {
        public Task<string> InvokeAsync(Uri requestUri)
        {
            var path = requestUri.GetComponents(UriComponents.Path, UriFormat.Unescaped);
            var pathElements = path.Split('/');

            var groupUrlName = pathElements[0];
            var resourceName = "groups";
            if (pathElements.Length > 1) resourceName = pathElements[1];

            var embeddedResourceName = $"NNUG.WebSite.App_Data_DesignTime.{resourceName}-{groupUrlName}.json";
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