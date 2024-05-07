
using HtmlAgilityPack;

namespace RecipeApp
{
    /// <summary>
    /// Base class for parsers using the print node of a web page.
    /// </summary>
    public abstract class PrintNodeParserBase : IParser
    {
        public abstract Task<string?> ParseAsync(string url);

        /// <summary>
        /// Parses the <see cref="HtmlDocument"/> for a node with the string "print" in its class attribute.
        /// </summary>
        /// <param name="htmlDocument">HtmlDocument to parse</param>
        /// <returns>a collection of nodes that contain "print"</returns>
        /// <exception cref="ArgumentNullException">thrown if no nodes are found</exception>
        protected HtmlNodeCollection FindPrintNodes(HtmlDocument document)
        {
            var printNodes = document.DocumentNode.SelectNodes("[class*='print']");

            if (printNodes == null)
            {
                throw new ArgumentNullException(nameof(document), "Unable to find print node.");
            }
            else
            {
                return printNodes;
            }
        }
    }
}
