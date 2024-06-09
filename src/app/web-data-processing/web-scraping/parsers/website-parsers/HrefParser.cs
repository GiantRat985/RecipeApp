using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using RecipeApp.Exceptions;

namespace RecipeApp
{
    [Obsolete("Use PrintNodeParser instead.")]
    /// <summary>
    /// Parser using print node based searching. Attempts to find the hyperlink in the href attribute of the print button on a web page.
    /// </summary>
    public class HrefParser : PrintNodeParser
    {
        private const string hrefNode = "href";
        public override string? Parse(HtmlDocument content)
        {
            // Parses data for a print button.
            var printNodes = FindPrintNodes(content);

            // Parses print button node for the print page link.
            var hyperlink = FindNodeWithHref(printNodes);
            return hyperlink;
        }

        /// <summary>
        /// Attempts to extract the print page hyperlink from the href attribute in the given nodes.
        /// </summary>
        /// <param name="nodes">Collection of nodes to parse</param>
        /// <returns>the recipe's hyperlink <see cref="string"/> or null if parsing is unsuccessful.</returns>
        private string? FindNodeWithHref(HtmlNodeCollection nodes)
        {
            foreach (var node in nodes)
            {
                var href = node.GetAttributeValue(hrefNode, null);
                if (!string.IsNullOrEmpty(href) && ValidateLink(href))
                {
                    return href;
                }
            }
            return null;
        }
    }
}
