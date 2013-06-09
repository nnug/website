using NNUG.WebSite.Models;
using NUnit.Framework;

namespace WebSite.Test.Unit.Models
{
    [TestFixture]
    public class ChapterTests
    {
        [TestCase(Category = "Unit")]
        public void A_chapter_constructed_with_only_a_name_get_default_logo_twitter_and_meetup_group()
        {
            var chapter = new Chapter("Dummy");
            
            Assert.That(chapter.Name, Is.EqualTo("Dummy"));
            Assert.That(chapter.LogoFileName, Is.EqualTo("NNUGDummy_200.png"));
            Assert.That(chapter.TwitterName, Is.EqualTo("NNUGDummy"));
            Assert.That(chapter.MeetupGroupName, Is.EqualTo("nnug-dummy"));
        }

        [TestCase(Category = "Unit")]
        public void A_chapter_can_be_constructed_with_a_custom_meetup_group()
        {
            var chapter = new Chapter("Dummy", "nnugdummy");
            Assert.That(chapter.MeetupGroupName, Is.EqualTo("nnugdummy"));
            
        }
    }
}