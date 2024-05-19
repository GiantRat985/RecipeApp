using HtmlAgilityPack;

namespace RecipeApp
{
    /// <summary>
    /// Interface for parsers that use an <see cref="HtmlDocument"/> as the parameter
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public interface IParser
    {
        public string? Parse(string content);
    }
}
