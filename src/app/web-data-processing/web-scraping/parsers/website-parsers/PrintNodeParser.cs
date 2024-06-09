
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore.Query.Internal;
using RecipeApp.Exceptions;

namespace RecipeApp
{
    /// <summary>
    /// Uses <see cref="HtmlAgilityPack"/> to parse through a website for any nodes that contain a link to a print page.
    /// </summary>
    public class PrintNodeParser : HtmlDocumentParserBase
    {
        private readonly string[] _queries = ["action", "href"];

        /// <summary>
        /// Parses a web page for a print link
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public override string? Parse(HtmlDocument content)
        {
            var nodes = FindPrintNodes(content);
            var link = FindPrintLink(nodes);
            return link;
        }

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
                throw new ParsingFailureException($"{nameof(PrintNodeParser)} was unable to find any print node.");
            }
            else
            {
                return printNodes;
            }
        }

        private string? FindPrintLink(HtmlNodeCollection nodes)
        {
            // For each child node of the print node...
            foreach (var node in nodes)
            {
                // ...parse for attribute using each xpath query...
                foreach (var query in  _queries)
                {
                    var link = node.GetAttributeValue(query, null);
                    // ...if found, return link, if not, continue to iterate
                    if (!string.IsNullOrEmpty(link) && ValidateLink(link))
                    {
                        return link;
                    }
                }
            }
            throw new ParsingFailureException($"{nameof(PrintNodeParser)} was unable to find a valid link in print nodes.");
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
