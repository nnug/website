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
            _httpGetStringCommand = Substitute.For<IHttpGetStringCommand>();
            _httpGetStringCommand.Invoke(Arg.Any<Uri>()).Returns(Task.FromResult(TestData.EventResponse.EventsNnugTrondheim));
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
        }

        [TestCase(Category = "Unit")]
        public async void Milliseconds_since_epoch_date_times_are_parsed_correctly()
        {
            var meetupApiClient = new MeetupApiClient(_meetupSettings, _httpGetStringCommand);
            var events = await meetupApiClient.GetEvents("nnug-trondheim");
            Assert.That(events.First().StartTime, Is.EqualTo(new DateTime(2013, 6, 20, 18, 0, 0)));
        }
    }
}