using System;
using System.Collections.Specialized;
using System.Configuration;

namespace NNUG.WebSite.ServiceAgent
{
    public class MeetupSettings : IMeetupSettings
    {
        public Uri GetSignedGroupUri(string meetupGroupName)
        {
            var signedEventUrls = (NameValueCollection)ConfigurationManager.GetSection("meetup/signedGroupUrls");
            return new Uri(signedEventUrls[meetupGroupName]);
        }

        public Uri GetSignedEventUri(string meetupGroupName)
        {
            var signedEventUrls = (NameValueCollection)ConfigurationManager.GetSection("meetup/signedEventUrls");
            return new Uri(signedEventUrls[meetupGroupName]);
        }
    }
}