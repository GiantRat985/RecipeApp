using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class WebProcessor
    {
        private readonly IModelFactory _modelFactory;
        private readonly IRepository<RecipeModelHtml> _repository;
        private readonly IScraper _scraper;

        public WebProcessor(IModelFactory modelFactory, IRepository<RecipeModelHtml> repository, IScraper scraper)
        {
            _modelFactory = modelFactory;
            _repository = repository;
            _scraper = scraper;
        }

        public async Task Process(string url)
        {
            var content = await _scraper.ScrapeWebPageAsync(url);
            var recipeModel = _modelFactory.CreateRecipeModel(content);
        }
    }
}
