using NNUG.WebSite.ServiceAgent;
using NUnit.Framework;

namespace WebSite.Test.Integration.ServiceAgent
{
    [TestFixture]
    public class MeetupSettingsTests
    {
        private MeetupSettings _meetupSettings;

        [SetUp]
        public void SetUp()
        {
            _meetupSettings = new MeetupSettings();
        }

        [TestCase(Category = "Integration")]
        public void Signed_event_url_can_be_read_from_configuration()
        {
            var signedEventUrl = _meetupSettings.GetSignedEventUri("meetupgroupname2");

            Assert.That(signedEventUrl.Query, Is.StringContaining("meetupgroupname2"));
        }

        [TestCase(Category = "Unit")]
        public void Signed_group_information_url_can_be_read_from_configuration()
        {
            var signedGroupUrl = _meetupSettings.GetSignedGroupUri("meetupgroupname2");

            Assert.That(signedGroupUrl.Query, Is.StringContaining("meetupgroupname2"));            
        }
    }
}