using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    /// <summary>
    /// Model layer abstraction for repository commands.
    /// </summary>
    public class RecipeRepository(IRepository<RecipeModelHtml> repository)
    {
        private readonly IRepository<RecipeModelHtml> _repository = repository;

        public async Task CreateRecipe(RecipeModelHtml recipe)
        {
            await _repository.AddAsync(recipe);
        }
        public async Task<IEnumerable<RecipeModelHtml>> GetAllRecipesAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<RecipeModelHtml> GetRecipeAsync(int id)
        {
            return await _repository.GetAsync(id);
        }
        public async Task UpdateRecipe(RecipeModelHtml recipe)
        {
            await _repository.UpdateAsync(recipe);
        }
        public async Task DeleteRecipe(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
