using System;

namespace NNUG.WebSite.ServiceAgent
{
    public interface IMeetupSettings
    {
        Uri GetSignedGroupUri(string meetupGroupName);
        Uri GetSignedEventUri(string meetupGroupName);
    }
}