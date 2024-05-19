using System.Diagnostics;
using System.Windows;

namespace RecipeApp
{
    /// <summary>
    /// Scrapes data from web pages.
    /// </summary>
    /// <param name="actionParser"></param>
    /// <param name="hrefParser"></param>
    public class ScraperService : IScraper
    {
        private readonly IDataFetcher _fetcher;
        private readonly ParserManager _parserManager;
        private readonly RecipeExtractor _recipeExtractor;

        public ScraperService(ParserManager parserManager, IDataFetcher fetcher, RecipeExtractor recipeExtractor)
        {
            _parserManager = parserManager;
            _fetcher = fetcher;
            _recipeExtractor = recipeExtractor;
        }

        /// <summary>
        /// Attempts to extract hyperlink from a url asynchronously
        /// </summary>
        /// <param name="url">targeted web page</param>
        /// <returns><see cref="string"/> contents of the recipe page.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string?> ScrapeWebPageAsync(string url)
        {
            // Fetch page contents
            var content = await _fetcher.FetchAndCacheAsync(url);

            // Parse the page
            foreach (var parser in _parserManager)
            {
                var hyperlink = parser.Parse(content);
                // If the parser successfully finds the recipe link, return the html content as a string.
                if (!string.IsNullOrEmpty(hyperlink))
                {
                    return await _recipeExtractor.ExtractRecipeContents(hyperlink);
                }
            }

            // If none can be found:
            MessageBox.Show("Unable to find recipe.");
            return null;
        }
    }
}


