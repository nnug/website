using System;
using System.Collections.Specialized;
using System.Configuration;

namespace NNUG.WebSite.Core.ServiceAgent
{
    public class MeetupSettings : IMeetupSettings
    {
        public Uri GetSignedGroupUri(string meetupGroupUrl)
        {
            var signedEventUrls = (NameValueCollection)ConfigurationManager.GetSection("meetup/signedGroupUrls");
            return new Uri(signedEventUrls[meetupGroupUrl]);
        }

        public Uri GetSignedEventUri(string meetupGroupUrl)
        {
            var signedEventUrls = (NameValueCollection)ConfigurationManager.GetSection("meetup/signedEventUrls");
            return new Uri(signedEventUrls[meetupGroupUrl]);
        }
    }
}