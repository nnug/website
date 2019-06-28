using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Models;
using NSubstitute;
using NUnit.Framework;

namespace WebSite.Test.Unit.Models
{
    [TestFixture]
    public class OrganizationTests
    {
        private Organization _organization;

        private IHttpGetStringCommand _httpGetStringCommand;

        [SetUp]
        public void SetUp()
        {
            _httpGetStringCommand = Substitute.For<IHttpGetStringCommand>();
            _httpGetStringCommand.InvokeAsync(Arg.Is<Uri>(u => !u.Segments.Last().EndsWith("/events"))).Returns(Task.FromResult(TestData.MeetupApiResponse.GroupNnugTrondheim));
            _httpGetStringCommand.InvokeAsync(Arg.Is<Uri>(u => u.Segments.Last().EndsWith("/events"))).Returns(Task.FromResult(TestData.MeetupApiResponse.EventsNnugTrondheim));
        }

        [TestCase(Category = "Unit")]
        public async Task NNUG_has_seven_chapters()
        {
            _organization = await Organization.Create(_httpGetStringCommand);
            Assert.That(_organization.Chapters.Count, Is.EqualTo(7));
        }

        [TestCase(Category = "Unit")]
        public async Task Meetup_group_information_can_not_be_retrieved_when_communication_with_meetup_dot_com_fails()
        {
            _httpGetStringCommand = Substitute.For<IHttpGetStringCommand>();
            _httpGetStringCommand.InvokeAsync(Arg.Any<Uri>()).Returns<string>(c => throw new HttpRequestException("Dummy"));
            _organization = await Organization.Create(_httpGetStringCommand);
            Assert.That(_organization.Chapters.First().MeetupGroup, Is.Null);
        }
    }
}