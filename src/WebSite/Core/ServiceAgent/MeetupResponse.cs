using System.Collections.Generic;

namespace NNUG.WebSite.Core.ServiceAgent
{
    public class MeetupResponse<T>
    {
        public List<T> Results { get; set; }
    }
}