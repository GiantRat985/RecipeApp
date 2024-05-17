using HtmlAgilityPack;

namespace RecipeApp
{
    /// <summary>
    /// Interface for parsers that use an <see cref="HtmlDocument"/> as the parameter
    /// </summary>
    public interface IParserAsync
    {
        public Task<string?> ParseAsync(string url);
    }
}
