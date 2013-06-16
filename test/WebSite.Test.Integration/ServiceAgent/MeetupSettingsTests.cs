using NNUG.WebSite.ServiceAgent;
using NUnit.Framework;

namespace WebSite.Test.Integration.ServiceAgent
{
    [TestFixture]
    public class MeetupSettingsTests
    {
        [TestCase(Category = "Integration")]
        public void Signed_event_url_can_be_read_from_configuration()
        {
            var meetupSettings = new MeetupSettings();
            var signedEventUrl = meetupSettings.GetSignedEventUri("meetupgroupname2");

            Assert.That(signedEventUrl.Query, Is.StringContaining("meetupgroupname2"));
        }
    }
}