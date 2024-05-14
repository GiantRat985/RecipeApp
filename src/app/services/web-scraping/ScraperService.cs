namespace RecipeApp
{
    /// <summary>
    /// Scrapes data from web pages.
    /// </summary>
    /// <param name="actionParser"></param>
    /// <param name="hrefParser"></param>
    /// <remarks>
    /// 
    /// TODO: A managing class should be implemented to manage parsers.
    /// 
    /// </remarks>
    public class ScraperService(IParser actionParser, IParser hrefParser)
    {
        // These fields should be wrapped in a managing class to allow for easier expansion
        private readonly IParser _actionParser = actionParser;
        private readonly IParser _hrefParser = hrefParser;


        /// <summary>
        /// Attempts to extract hyperlink from a url asynchronously
        /// </summary>
        /// <param name="url">targeted web page</param>
        /// <returns>hyperlink <see cref="string"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string> ScrapeWebPage(string url)
        {
            //Try to find the print page hyperlink in the href attribute.
            var hyperlink = await _hrefParser.ParseAsync(url);
            if (hyperlink != null)
            {
                return hyperlink;
            }
            
            //Try to find the print page hyperlink in the action attribute.
            hyperlink = await _actionParser.ParseAsync(url);
            if (hyperlink != null)
            {
                return hyperlink;
            }

            //If none can be found, throw an exception.
            throw new ArgumentNullException(nameof(ScrapeWebPage), "Unable to find recipe hyperlink.");
        }
    }
}


