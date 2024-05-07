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
    /// Parser using print node based searching. Attempts to find the hyperlink in the href attribute of the print button on a web page.
    /// </summary>
    public class HrefParser : PrintNodeParserBase
    {
        private readonly IDataFetcher _dataFetcher;

        public HrefParser(IDataFetcher dataFetcher)
        {
            _dataFetcher = dataFetcher;
        }

        public override async Task<string?> ParseAsync(string url)
        {
            var document = await _dataFetcher.FetchAndCacheAsync(url);
            var printNodes = FindPrintNodes(document);
            var hyperlink = FindNodeWithHref(printNodes);
            return hyperlink;
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
