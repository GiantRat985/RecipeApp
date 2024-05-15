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
        private List<IParser> _parsers = new List<IParser>();

        public ScraperService(IDataFetcher dataFetcher)
        {
            // Initialize parsers here.
            _parsers = new List<IParser>()
            {
                new ActionParser(dataFetcher),
                new HrefParser(dataFetcher),
            };
        }

        /// <summary>
        /// Attempts to extract hyperlink from a url asynchronously
        /// </summary>
        /// <param name="url">targeted web page</param>
        /// <returns>hyperlink <see cref="string"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string> ScrapeWebPageAsync(string url)
        {

            foreach (var parser in _parsers)
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


