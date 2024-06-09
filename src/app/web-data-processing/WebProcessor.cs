using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RecipeApp
{
    public class WebProcessor
    {
        private readonly RecipeRepository _repository;
        private readonly ScraperService _scraper;
        private readonly PrintPageExtractor _extractor;

        public WebProcessor(RecipeRepository repository, ScraperService scraper, PrintPageExtractor extractor)
        {
            _repository = repository;
            _scraper = scraper;
            _extractor = extractor;
        }

        public async Task Process(string url)
        {
            try
            {
                var printLink = await _scraper.ScrapeWebPageAsync(url);
                var metadata = await _scraper.ScrapeMetadata(url);
                var content = await _extractor.ExtractRecipeContents(printLink);
                var model = new RecipeData()
                {
                    HtmlContent = content,
                    WebsiteUrl = url,
                    Title = metadata.Title,
                    Author = metadata.Author,
                };
                await _repository.AddAsync(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
