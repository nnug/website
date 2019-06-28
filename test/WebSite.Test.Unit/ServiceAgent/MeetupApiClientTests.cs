using System;
using System.Linq;
using System.Threading.Tasks;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Core.ServiceAgent;
using NSubstitute;
using NUnit.Framework;

namespace WebSite.Test.Unit.ServiceAgent
{
    [TestFixture]
    public class MeetupApiClientTests
    {
        private IHttpGetStringCommand _httpGetStringCommand;

        [SetUp]
        public void SetUp()
        {
            _httpGetStringCommand = Substitute.For<IHttpGetStringCommand>();
            _httpGetStringCommand.InvokeAsync(Arg.Is<Uri>(u => u.Segments.Last() == "nnug-trondheim")).Returns(Task.FromResult(TestData.MeetupApiResponse.GroupNnugTrondheim));
            _httpGetStringCommand.InvokeAsync(Arg.Is<Uri>(u => u.Segments.Last() == "events")).Returns(Task.FromResult(TestData.MeetupApiResponse.EventsNnugTrondheim));
        }

        [TestCase(Category = "Unit")]
        public void A_new_instance_can_be_created_with_required_dependencies()
        {
            var meetupApiClient = new MeetupApiClient(_httpGetStringCommand);
            Assert.That(meetupApiClient, Is.Not.Null);
        }

        [TestCase(Category = "Unit")]
        public async Task Events_for_a_meetup_group_can_be_retrieved_through_the_meetup_api_client()
        {
            var meetupApiClient = new MeetupApiClient(_httpGetStringCommand);
            var events = await meetupApiClient.GetEvents("nnug-trondheim");
            Assert.That(events, Has.Count.EqualTo(2));
            Assert.That(events.First().Name, Is.EqualTo("Sommerfest"));
        }

        [TestCase(Category = "Unit")]
        public async Task Milliseconds_since_epoch_date_times_are_parsed_correctly()
        {
            var meetupApiClient = new MeetupApiClient(_httpGetStringCommand);
            var events = await meetupApiClient.GetEvents("nnug-trondheim");
            Assert.That(events.First().StartTime, Is.EqualTo(new DateTime(2013, 6, 20, 18, 0, 0)));
        }

        [TestCase(Category = "Unit")]
        public async Task Group_information_can_be_retrieved_through_the_meetup_api_client()
        {
            var meetupApiClient = new MeetupApiClient(_httpGetStringCommand);
            var groupInformation = await meetupApiClient.GetGroupInformation("nnug-trondheim");
            Assert.That(groupInformation, Is.Not.Null);
            Assert.That(groupInformation.Name, Is.EqualTo("NNUG Trondheim"));
        }
    }
}