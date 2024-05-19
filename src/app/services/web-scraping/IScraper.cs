using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public interface IScraper
    {
        public Task<string?> ScrapeWebPageAsync(string url);
    }
}
