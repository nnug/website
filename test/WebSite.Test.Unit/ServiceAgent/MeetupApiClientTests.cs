using System;
using System.Linq;
using System.Threading.Tasks;
using NNUG.WebSite.Integration;
using NNUG.WebSite.ServiceAgent;
using NSubstitute;
using NUnit.Framework;

namespace WebSite.Test.Unit.ServiceAgent
{
    [TestFixture]
    public class MeetupApiClientTests
    {
        private IMeetupSettings _meetupSettings;
        private IHttpGetStringCommand _httpGetStringCommand;

        [SetUp]
        public void SetUp()
        {
            _meetupSettings = Substitute.For<IMeetupSettings>();
            _meetupSettings.GetSignedGroupUri(Arg.Any<string>()).Returns(new Uri("http://api.meetup.com/2/group?meetupgroupname1"));
            _meetupSettings.GetSignedEventUri(Arg.Any<string>()).Returns(new Uri("http://api.meetup.com/2/events?meetupgroupname1"));
            _httpGetStringCommand = Substitute.For<IHttpGetStringCommand>();
            _httpGetStringCommand.Invoke(Arg.Is<Uri>(u => u.PathAndQuery.Contains("/group"))).Returns(Task.FromResult(TestData.MeetupApiResponse.GroupNnugTrondheim));
            _httpGetStringCommand.Invoke(Arg.Is<Uri>(u => u.PathAndQuery.Contains("/events"))).Returns(Task.FromResult(TestData.MeetupApiResponse.EventsNnugTrondheim));
        }

        [TestCase(Category = "Unit")]
        public void A_new_instance_can_be_created_with_default_dependencies()
        {
            var meetupApiClient = new MeetupApiClient();
            Assert.That(meetupApiClient, Is.Not.Null);
        }

        [TestCase(Category = "Unit")]
        public async void Events_for_a_meetup_group_can_be_retrieved_through_the_meetup_api_client()
        {
            var meetupApiClient = new MeetupApiClient(_meetupSettings, _httpGetStringCommand);
            var events = await meetupApiClient.GetEvents("nnug-trondheim");
            Assert.That(events, Has.Count.EqualTo(2));
            Assert.That(events.First().Name, Is.EqualTo("Sommerfest"));
        }

        [TestCase(Category = "Unit")]
        public async void Milliseconds_since_epoch_date_times_are_parsed_correctly()
        {
            var meetupApiClient = new MeetupApiClient(_meetupSettings, _httpGetStringCommand);
            var events = await meetupApiClient.GetEvents("nnug-trondheim");
            Assert.That(events.First().StartTime, Is.EqualTo(new DateTime(2013, 6, 20, 18, 0, 0)));
        }

        [TestCase(Category = "Unit")]
        public async void Group_information_can_be_retrieved_through_the_meetup_api_client()
        {
            var meetupApiClient = new MeetupApiClient(_meetupSettings, _httpGetStringCommand);
            var groupInformation = await meetupApiClient.GetGroupInformation("nnug-trondheim");
            Assert.That(groupInformation, Is.Not.Null);
            Assert.That(groupInformation.Name, Is.EqualTo("NNUG Trondheim"));
        }
    }
}