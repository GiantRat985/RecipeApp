using HtmlAgilityPack;

namespace RecipeApp
{
    public interface IDataFetcher
    {
        /// <summary>
        /// Fetches data associated with the given url as an asynchronous operation.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>The html content <see cref="string"/> associated with the given url.</returns>
        public Task<string> FetchAndCacheAsync(string url);
    }
}