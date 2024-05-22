
using HtmlAgilityPack;
using RecipeApp.Exceptions;

namespace RecipeApp
{
    /// <summary>
    /// Base class for parsers using the print node of a web page.
    /// </summary>
    public abstract class PrintNodeParserBase : IParser
    {
        public abstract string? Parse(string url);

        /// <summary>
        /// Parses the <see cref="HtmlDocument"/> for a node with the string "print" in its class attribute.
        /// </summary>
        /// <param name="htmlDocument">HtmlDocument to parse</param>
        /// <returns>a collection of nodes that contain "print"</returns>
        /// <exception cref="ArgumentNullException">thrown if no nodes are found</exception>
        protected HtmlNodeCollection FindPrintNodes(HtmlDocument document)
        {
            string xpathQuery = "//*[@class[contains(., 'print')]]";
            var printNodes = document.DocumentNode.SelectNodes(xpathQuery);

            if (printNodes == null)
            {
                throw new ParsingFailureException("Unable to find print node.");
            }
            else
            {
                return printNodes;
            }
        }
        protected bool ValidateLink(string url)
        {
            if (url.Contains("https") || url.Contains(".com") || url.Contains(".org"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
