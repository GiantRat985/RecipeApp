using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;

namespace RecipeApp
{
    public class DataFetcher : IDataFetcher
    {
        private readonly HttpClient _httpClient;
        private readonly ConcurrentDictionary<string, HtmlDocument> _cache;

        public DataFetcher(HttpClient httpClient)
        {
            _httpClient = httpClient;
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

            //If not found, load, cache and return new data
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var htmlContent = await response.Content.ReadAsStringAsync();
            htmlDocument.LoadHtml(htmlContent);
            _cache.TryAdd(key, htmlDocument);

            return htmlDocument;
        }
    }
}
