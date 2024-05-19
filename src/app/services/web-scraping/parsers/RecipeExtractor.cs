using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RecipeApp
{
    public class RecipeExtractor
    {
        private readonly IDataFetcher _dataFetcher;

        public RecipeExtractor(IDataFetcher dataFetcher)
        {
            _dataFetcher = dataFetcher;
        }

        public async Task<string> ExtractRecipeContents(string url)
        {
            return await _dataFetcher.FetchAndCacheAsync(url);
        }
    }
}
