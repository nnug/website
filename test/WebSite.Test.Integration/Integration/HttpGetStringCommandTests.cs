using System;
using System.Threading.Tasks;
using NNUG.WebSite.Core.Integration;
using NUnit.Framework;

namespace WebSite.Test.Integration.Integration
{
    [TestFixture]
    public class HttpGetStringCommandTests
    {
        private HttpGetStringCommand _httpGetStringCommand;

        [SetUp]
        public void SetUp()
        {
            _httpGetStringCommand = new HttpGetStringCommand();
        }

        [TestCase(Category = "Integration")]
        public async Task The_response_of_a_http_get_command_can_be_retrieved_as_a_string()
        {
            var response = await _httpGetStringCommand.InvokeAsync(new Uri("https://www.vg.no"));

            Assert.That(response, Has.Length.GreaterThan(0));
        }
    }
}