using System.Diagnostics;
using System.Windows;

namespace RecipeApp
{
    /// <summary>
    /// Scrapes data from web pages.
    /// </summary>
    /// <param name="actionParser"></param>
    /// <param name="hrefParser"></param>
    public class ScraperService
    {
        private readonly ParserManager _parserManager;

        public ScraperService(ParserManager parserManager)
        {
            _parserManager = parserManager;
        }

        /// <summary>
        /// Attempts to extract hyperlink from a url asynchronously
        /// </summary>
        /// <param name="url">targeted web page</param>
        /// <returns>hyperlink <see cref="string"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string> ScrapeWebPageAsync(string url)
        {

            foreach (var parser in _parserManager)
            {
                var hyperlink = await parser.ParseAsync(url);
                if (hyperlink != null)
                {
                    return hyperlink;
                }
            }

            // If none can be found:
            MessageBox.Show("Unable to find recipe.");
            return "";
        }
    }
}


