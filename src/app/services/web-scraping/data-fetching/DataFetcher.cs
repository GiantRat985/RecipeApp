using System.Collections.Concurrent;
using System.Net.Http;
using HtmlAgilityPack;

namespace RecipeApp
{
    public class DataFetcher : IDataFetcher
    {
        private readonly ConcurrentDictionary<string, HtmlDocument> _cache;

        public DataFetcher()
        {
            _cache = new ConcurrentDictionary<string, HtmlDocument>();
        }

        /// <summary>
        /// Fetches data associated with the given url as an asynchronous operation.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>The <see cref="HtmlDocument"/> associated with the given url.</returns>
        public async Task<HtmlDocument> FetchAndCacheAsync(string url)
        {
            var key = url.GetHashCode().ToString();
            var htmlDocument = new HtmlDocument();

            //If data is found in the cache, return data
            if (_cache.TryGetValue(key, out var cachedData))
            {
                return cachedData;
            }

            // If data is not found, create a new HTTP client, and load data from url
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var htmlContent = await response.Content.ReadAsStringAsync();
            htmlDocument.LoadHtml(htmlContent);
            _cache.TryAdd(key, htmlDocument);

            return htmlDocument;
        }
    }
}
