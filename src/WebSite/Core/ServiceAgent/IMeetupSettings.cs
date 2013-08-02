using System;

namespace NNUG.WebSite.Core.ServiceAgent
{
    public interface IMeetupSettings
    {
        Uri GetSignedGroupUri(string meetupGroupUrl);
        Uri GetSignedEventUri(string meetupGroupUrl);
    }
}