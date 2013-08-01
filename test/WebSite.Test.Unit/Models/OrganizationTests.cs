using NNUG.WebSite.Models;
using NUnit.Framework;

namespace WebSite.Test.Unit.Models
{
    [TestFixture]
    public class OrganizationTests
    {
        private Organization _organization = Organization.Create();

        [TestCase(Category = "Unit")]
        public void NNUG_has_seven_chapters()
        {
            Assert.That(_organization.Chapters.Count, Is.EqualTo(7));
        }
    }
}