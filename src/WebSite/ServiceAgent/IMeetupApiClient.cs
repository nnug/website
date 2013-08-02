using System.Collections.Generic;
using System.Threading.Tasks;
using NNUG.WebSite.Models;

namespace NNUG.WebSite.ServiceAgent
{
    public interface IMeetupApiClient
    {
        Task<ICollection<Event>> GetEvents(string meetupGroupUrl);
    }
}