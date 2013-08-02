using System.Threading.Tasks;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Core.ServiceAgent;
using NUnit.Framework;

namespace WebSite.Test.Integration.Integration
{
    [TestFixture]
    public class HttpGetStringFromEmbeddedResourceCommandTests
    {
        private MeetupSettings _meetupSettings;
        private HttpGetStringFromEmbeddedResourceCommand _httpGetStringFromEmbeddedResourceCommand;

        [SetUp]
        public void SetUp()
        {
            _meetupSettings = new MeetupSettings();
            _httpGetStringFromEmbeddedResourceCommand = new HttpGetStringFromEmbeddedResourceCommand();
        }

        [TestCase(Category = "Integration")]
        public async Task Design_time_data_can_be_retrieved_from_embedded_resource()
        {
            var designTimeData = await _httpGetStringFromEmbeddedResourceCommand.InvokeAsync(_meetupSettings.GetSignedGroupUri("nnug-trondheim"));

            Assert.That(designTimeData, Is.StringContaining("NNUG Trondheim"));
        }
    }
}