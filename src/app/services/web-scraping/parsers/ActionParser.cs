using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RecipeApp
{
    /// <summary>
    /// Parser using print node based searching. Attempts to find the hyperlink in the action attribute of the print button on a web page.
    /// </summary>
    public class ActionParser : PrintNodeParserBase
    {
        private readonly IDataFetcher _dataFetcher;

        public ActionParser(IDataFetcher fetcher)
        {
            _dataFetcher = fetcher;
        }


        public override async Task<string?> ParseAsync(string url)
        {
            var document = await _dataFetcher.FetchAndCacheAsync(url);
            var printNodes = FindPrintNodes(document);
            var hyperlink = FindNodeWithAction(printNodes);
            return hyperlink;
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
                var action = node.Attributes["action"];
                if (action != null && !string.IsNullOrEmpty(action.Value))
                {
                    return action.Value;
                }
            }
            return null;
        }
    }
}
