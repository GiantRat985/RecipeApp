using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RecipeApp
{
    /// <summary>
    /// Extracts html contents from a recipe's print page.
    /// </summary>
    public class PrintPageExtractor
    {
        private readonly IDataFetcher _dataFetcher;

        public PrintPageExtractor(IDataFetcher dataFetcher)
        {
            _dataFetcher = dataFetcher;
        }

        /// <summary>
        /// Extracts html content from a recipe's print page
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> ExtractRecipeContents(string url)
        {
            return await _dataFetcher.FetchAndCacheAsync(url);
        }
    }
}
