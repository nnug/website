using NNUG.WebSite.Models;
using NUnit.Framework;

namespace WebSite.Test.Unit.Models
{
    [TestFixture]
    public class ChapterTests
    {
        [TestCase(Category = "Unit")]
        public void A_chapter_constructed_with_a_group_url_fragment_and_twitter_name()
        {
            var chapter = new Chapter(null, null, "DummyGroupUrl", "DummyTwitterName");

            Assert.That(chapter.MeetupGroupUrl, Is.EqualTo("DummyGroupUrl"));
            Assert.That(chapter.LogoFileName, Is.EqualTo("DummyGroupUrl_200.png"));
            Assert.That(chapter.TwitterName, Is.EqualTo("DummyTwitterName"));
        }
    }
}