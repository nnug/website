using System;

namespace NNUG.WebSite.ServiceAgent
{
    public interface IMeetupSettings
    {
        Uri GetSignedGroupUri(string meetupGroupUrl);
        Uri GetSignedEventUri(string meetupGroupUrl);
    }
}