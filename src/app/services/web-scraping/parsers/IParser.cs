using HtmlAgilityPack;

namespace RecipeApp
{
    /// <summary>
    /// Interface for parsers that use an <see cref="HtmlDocument"/> as the parameter
    /// </summary>
    public interface IParser
    {
        public Task<string?> ParseAsync(string url);
    }
}
