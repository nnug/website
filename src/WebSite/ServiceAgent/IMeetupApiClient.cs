using System.Collections.Generic;
using System.Threading.Tasks;
using NNUG.WebSite.Models;

namespace NNUG.WebSite.ServiceAgent
{
    public interface IMeetupApiClient
    {
        Task<IEnumerable<Event>> GetEvents(string meetupGroupName);
    }
}