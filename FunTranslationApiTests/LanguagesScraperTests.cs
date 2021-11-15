using NUnit.Framework;
using RecruitmentTaskForJuniorASF.Data;
using RecruitmentTaskForJuniorASF.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentTaskForJuniorASFTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ScrapAvailableLanguages_ReceivedListIsNotEmpty()
        {
            var LanguagesLists = LanguagesScraper.ScrapAvailableLanguages();
            Assert.That(LanguagesLists, Is.Not.Empty);
        }

        [Test]
        public void ScrapAvailableLanguages_ConainsLeetSpeak()
        {
            var LanguagesLists = LanguagesScraper.ScrapAvailableLanguages();
            Assert.That(LanguagesLists.Any(p=>p.LanguageUnit == "\nLeetspeak\n"));
        }

        [Test]
        public void ScrapAvailableLanguages_IsTypeOExpectedList()
        {
            var LanguagesLists = LanguagesScraper.ScrapAvailableLanguages();
            Assert.That(LanguagesLists, Is.TypeOf<List<Language>>());
        }


    }
}