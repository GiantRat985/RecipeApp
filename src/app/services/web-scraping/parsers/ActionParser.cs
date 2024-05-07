using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RecipeApp
{
    public class ActionParser : IParser
    {
        private readonly IDataFetcher _dataFetcher;

        public ActionParser(IDataFetcher fetcher)
        {
            _dataFetcher = fetcher;
        }

        public async Task<string?> ParseAsync(string url)
        {
            var document = await _dataFetcher.FetchAndCacheAsync(url);
            var printNodes = FindPrintNodes(document);
            var hyperlink = FindNodeWithAction(printNodes);
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
        /// Attempts to extract the print page hyperlink from the action attribute in the given nodes.
        /// </summary>
        /// <param name="nodes">Collection of nodes to parse</param>
        /// <returns>the recipe's hyperlink <see cref="string"/></returns>
        private string? FindNodeWithAction(HtmlNodeCollection nodes)
        {
            foreach (var node in nodes)
            {
                var action = node.GetAttributeValue("action", null);
                if (!string.IsNullOrEmpty(action))
                {
                    return action;
                }
            }
            return null;
        }
    }
}
