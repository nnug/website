using System;

namespace NNUG.WebSite.ServiceAgent
{
    public interface IMeetupSettings
    {
        Uri GetSignedEventUri(string meetupGroupName);
    }
}