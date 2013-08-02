using System;
using System.Threading.Tasks;

namespace NNUG.WebSite.Core.Integration
{
    public interface IHttpGetStringCommand
    {
        Task<string> InvokeAsync(Uri requestUri);
    }
}