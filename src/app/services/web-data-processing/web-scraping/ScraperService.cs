using System.Diagnostics;
using System.Windows;
using HtmlAgilityPack;
using RecipeApp.Exceptions;

namespace RecipeApp
{
    /// <summary>
    /// Scrapes data from web pages
    /// </summary>
    /// <param name="actionParser"></param>
    /// <param name="hrefParser"></param>
    /// <remarks>
    /// This class should be registered with the service collection
    /// </remarks>
    public class ScraperService : IScraper
    {
        private readonly IDataFetcher _fetcher;
        private readonly ParserManager _parserManager;
        private readonly RecipeExtractor _recipeExtractor;

        public ScraperService(IDataFetcher fetcher)
        {
            _fetcher = fetcher;
            _parserManager = new ParserManager();
            _recipeExtractor = new RecipeExtractor(fetcher);
        }

        /// <summary>
        /// Attempts to extract hyperlink from a url asynchronously
        /// </summary>
        /// <param name="url">targeted web page</param>
        /// <returns><see cref="string"/> contents of the recipe page.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string> ScrapeWebPageAsync(string url)
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

            // If none can be found, throw exception
            throw new ParsingFailureException($"{nameof(ScrapeWebPageAsync)} failed. Unable to find data.");
        }


    }
}


