using System.Collections.Concurrent;
using System.Net.Http;
using HtmlAgilityPack;

namespace RecipeApp
{
    public class DataFetcher : IDataFetcher
    {
        private readonly ConcurrentDictionary<string, string> _cache;

        public DataFetcher()
        {
            _cache = new ConcurrentDictionary<string, string>();
        }

        /// <summary>
        /// Fetches data associated with the given url as an asynchronous operation.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>The html content <see cref="string"/>.</returns>
        public async Task<string> FetchAndCacheAsync(string url)
        {
            var key = url.GetHashCode().ToString();

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
            _cache.TryAdd(key, htmlContent);

            return htmlContent;
        }
    }
}
