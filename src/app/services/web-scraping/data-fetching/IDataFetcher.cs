using HtmlAgilityPack;

namespace RecipeApp
{
    public interface IDataFetcher
    {
        public Task<HtmlDocument> FetchAndCacheAsync(string url);
    }
}