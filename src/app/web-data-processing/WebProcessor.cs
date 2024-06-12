using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using RecipeApp.Exceptions;

namespace RecipeApp
{
    public class WebProcessor
    {
        private readonly RecipeRepository _repository;
        private readonly ScraperService _scraper;
        private readonly PrintPageExtractor _extractor;
        private readonly RecipeFormatter _formatter;

        public WebProcessor(RecipeRepository repository, ScraperService scraper, PrintPageExtractor extractor, RecipeFormatter formatter)
        {
            _repository = repository;
            _scraper = scraper;
            _extractor = extractor;
            _formatter = formatter;
        }

        public async Task Process(string url)
        {
            var printLink = await _scraper.ScrapeWebPageAsync(url);
            var metadata = await _scraper.ScrapeMetadata(url);
            var content = await _extractor.ExtractRecipeContents(printLink);
            var imageData = _formatter.HtmlToByteArray(content);
            var model = new RecipeData()
            {
                HtmlContent = content,
                WebsiteUrl = url,
                RecipeImage = imageData,
                Title = metadata.Title,
                Author = metadata.Author,
            };
            await _repository.AddAsync(model);
        }
    }
}
