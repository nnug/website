using NNUG.WebSite.Models;

namespace NNUG.WebSite.Core.ServiceAgent
{
    public interface IMeetupApiClient
    {
        Task<ICollection<Event>> GetEvents(string meetupGroupUrl);
    }
}
