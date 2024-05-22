using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public interface IScraper
    {
        /// <summary>
        /// Attempts to extract hyperlink from a url asynchronously
        /// </summary>
        /// <param name="url">targeted web page</param>
        /// <returns><see langword="string"/> contents of the recipe page.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<string> ScrapeWebPageAsync(string url);
    }
}
