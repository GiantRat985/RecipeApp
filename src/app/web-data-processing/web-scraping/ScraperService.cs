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
    public class ScraperService
    {
        private readonly IDataFetcher _fetcher;
        private readonly IHtmlDocumentParser _nodeParser;
        private readonly MetadataScraper _metadataParser;

        public ScraperService(IDataFetcher fetcher, PrintNodeParser printParser, MetadataScraper metadataParser)
        {
            _fetcher = fetcher;
            _nodeParser = printParser;
            _metadataParser = metadataParser;
        }

        /// <summary>
        /// Attempts to extract a print page hyperlink from a url as an asynchronous operation
        /// </summary>
        /// <param name="url">targeted web page</param>
        /// <returns><see cref="string"/> contents of the recipe page.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string> ScrapeWebPageAsync(string url)
        {
            // Fetch page contents
            var content = await _fetcher.FetchAndCacheAsync(url);
            var document = Helpers.LoadHtml(content);

            // Parse the page
            var link = _nodeParser.Parse(document);
            // If none can be found
            ParsingFailureException.ThrowIfNull(link, $"{nameof(ScrapeWebPageAsync)} failed. Unable to find data.");
            return link!;
        }

        /// <summary>
        /// Scrapes metadata from a webpage
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<RecipeMetadata> ScrapeMetadata(string url)
        {
            var content = await _fetcher.FetchAndCacheAsync(url);
            var document = Helpers.LoadHtml(content);

            return _metadataParser.ParseMetadata(document);
        }
    }
}


