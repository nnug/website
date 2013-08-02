using System;
using System.Linq;
using System.Threading.Tasks;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Core.ServiceAgent;
using NNUG.WebSite.Models;
using NSubstitute;
using NUnit.Framework;

namespace WebSite.Test.Unit.Models
{
    [TestFixture]
    public class OrganizationTests
    {
        private Organization _organization;

        private IMeetupSettings _meetupSettings;
        private IHttpGetStringCommand _httpGetStringCommand;

        [SetUp]
        public void SetUp()
        {
            _meetupSettings = Substitute.For<IMeetupSettings>();
            _meetupSettings.GetSignedGroupUri(Arg.Any<string>()).Returns(new Uri("http://api.meetup.com/2/groups?meetupgroupname1"));
            _meetupSettings.GetSignedEventUri(Arg.Any<string>()).Returns(new Uri("http://api.meetup.com/2/events?meetupgroupname1"));
            _httpGetStringCommand = Substitute.For<IHttpGetStringCommand>();
            _httpGetStringCommand.InvokeAsync(Arg.Is<Uri>(u => u.Segments.Last() == "groups")).Returns(Task.FromResult(TestData.MeetupApiResponse.GroupNnugTrondheim));
            _httpGetStringCommand.InvokeAsync(Arg.Is<Uri>(u => u.Segments.Last() == "events")).Returns(Task.FromResult(TestData.MeetupApiResponse.EventsNnugTrondheim));
        }

        [TestCase(Category = "Unit")]
        public async Task NNUG_has_seven_chapters()
        {
            _organization = await Organization.Create(_meetupSettings, _httpGetStringCommand);
            Assert.That(_organization.Chapters.Count, Is.EqualTo(7));
        }
    }
}