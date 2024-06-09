using HtmlAgilityPack;

namespace RecipeApp
{
    /// <summary>
    /// Interface for parsers that use an <see cref="HtmlDocument"/> as the parameter
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public interface IHtmlDocumentParser
    {
        public string? Parse(HtmlDocument content);
        public bool TryParse(HtmlDocument content, out string? parsedData);
    }
}
