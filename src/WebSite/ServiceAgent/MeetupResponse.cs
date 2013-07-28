using System.Collections.Generic;

namespace NNUG.WebSite.ServiceAgent
{
    public class MeetupResponse<T>
    {
        public List<T> Results { get; set; }
    }
}