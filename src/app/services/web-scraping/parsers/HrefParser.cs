using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RecipeApp
{
    public class HrefParser : IParser
    {
        private readonly IDataFetcher _dataFetcher;

        public HrefParser(IDataFetcher dataFetcher)
        {
            _dataFetcher = dataFetcher;
        }

        public async Task<string?> ParseAsync(string url)
        {
            var document = await _dataFetcher.FetchAndCacheAsync(url);
            var printNodes = FindPrintNodes(document);
            var hyperlink = FindNodeWithHref(printNodes);
            return hyperlink;
        }

        /// <summary>
        /// Parses the <see cref="HtmlDocument"/> for a node with the string "print" in its class attribute.
        /// </summary>
        /// <param name="htmlDocument">HtmlDocument to parse</param>
        /// <returns>a collection of nodes that contain "print"</returns>
        /// <exception cref="ArgumentNullException">thrown if no nodes are found</exception>
        private HtmlNodeCollection FindPrintNodes(HtmlDocument document)
        {
            var printNodes = document.DocumentNode.SelectNodes("[class*='print']");

            if (printNodes == null)
            {
                throw new ArgumentNullException("Unable to find print node.");
            }
            else
            {
                return printNodes;
            }
        }

        /// <summary>
        /// Attempts to extract the print page hyperlink from the href attribute in the given nodes.
        /// </summary>
        /// <param name="nodes">Collection of nodes to parse</param>
        /// <returns>the recipe's hyperlink <see cref="string"/></returns>
        private string? FindNodeWithHref(HtmlNodeCollection nodes)
        {
            foreach (var node in nodes)
            {
                var href = node.GetAttributeValue("href", null);
                if (!string.IsNullOrEmpty(href))
                {
                    return href;
                }
            }
            return null;
        }
    }
}
