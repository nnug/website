using System;
using System.Threading.Tasks;
using NNUG.WebSite.Integration;
using NUnit.Framework;

namespace WebSite.Test.Integration.Integration
{
    [TestFixture]
    public class HttpGetStringCommandTests
    {
        [TestCase(Category = "Integration")]
        public async Task The_response_of_a_http_get_command_can_be_retrieved_as_a_string()
        {
            var httpGetStringCommand = new HttpGetStringCommand();
            var response = await httpGetStringCommand.Invoke(new Uri("http://www.vg.no"));

            Assert.That(response, Has.Length.GreaterThan(0));
        }
    }
}