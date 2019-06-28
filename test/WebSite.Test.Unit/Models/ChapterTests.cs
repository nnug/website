using NNUG.WebSite.Models;
using NUnit.Framework;

namespace WebSite.Test.Unit.Models
{
    [TestFixture]
    public class ChapterTests
    {
        [TestCase(Category = "Unit")]
        public void A_chapter_constructed_with_a_group_url_fragment_name_and_twitter_name_gets_a_logo_file_name_and_join_url()
        {
            var chapter = new Chapter(null, "DummyGroupUrl", "DummyName", "DummyTwitterName");

            Assert.That(chapter.LogoFileName, Is.EqualTo("DummyGroupUrl_200.png"));
            Assert.That(chapter.JoinUrl.ToString(), Does.EndWith("/DummyGroupUrl/join/"));
        }
    }
}