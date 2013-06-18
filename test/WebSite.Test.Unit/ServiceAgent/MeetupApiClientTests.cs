using System;
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
        }

        [TestCase(Category = "Integration")]
        public async void Events_for_a_meetup_group_can_be_retrieved_through_the_meetup_api()
        {
            _httpGetStringCommand.Invoke(Arg.Any<Uri>()).Returns(Task.FromResult(TestData.EventResponse.EventsNnugTrondheim));

            var meetupApiClient = new MeetupApiClient(_meetupSettings, _httpGetStringCommand);
            var events = await meetupApiClient.GetEvents("nnug-trondheim");
            Assert.That(events, Has.Count.EqualTo(2));
        }
    }
}