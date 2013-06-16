using System;
using System.Threading.Tasks;

namespace NNUG.WebSite.Integration
{
    public interface IHttpGetStringCommand
    {
        Task<string> Invoke(Uri requestUri);
    }
}