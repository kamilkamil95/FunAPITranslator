using HtmlAgilityPack;
using RecruitmentTaskForJuniorASF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RecruitmentTaskForJuniorASF.Data
{
    public static class LanguagesScraper
    {
        static HtmlWeb _funTranslationsWeb = new HtmlWeb();

        public static List<Language> ScrapAvailableLanguages()
        {
            var languagesList = new List<Language>();
            try
            {
                var languagesAvailableList = LanguageScraper();

                foreach (var language in languagesAvailableList)
                {
                    if (language.LanguageUnit != null)
                    {
                        var languageNameWithoutWhiteSpacerInName = language.LanguageUnit.Replace(" ", "");
                        languagesList.Add(new Language()
                        {
                            LanguageUnit = languageNameWithoutWhiteSpacerInName
                        });
                    }
                }
                NLogCommunicator.Info("Scraper status - OK");

                return languagesList;
            }
            catch (Exception ex)
            {
                NLogCommunicator.Error(ex);
                return languagesList;
            }
        }

        private static IEnumerable<Language> LanguageScraper()
        {
            var document = _funTranslationsWeb.Load(Consts.FunTranslationsApiWebUri);
            var tableRows = document.QuerySelectorAll("table tr").Skip(1).Take(70);

            foreach (var language in tableRows)
            {
                var tds = language.QuerySelectorAll("td");
                var languageName = tds[0].InnerText;
                yield return new Language()
                {
                    LanguageUnit = languageName,
                };
            }
        }
    }
}
