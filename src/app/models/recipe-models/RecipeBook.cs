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
    public class RecipeBook(IRepository<RecipeHtml> repository)
    {
        private readonly IRepository<RecipeHtml> _repository = repository;

        #region Repository Methods

        public async Task CreateRecipe(RecipeHtml recipe)
        {
            await _repository.AddAsync(recipe);
        }
        public async Task<IEnumerable<RecipeHtml>> GetAllRecipesAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<RecipeHtml> GetRecipeAsync(int id)
        {
            return await _repository.GetAsync(id);
        }
        public async Task UpdateRecipe(RecipeHtml recipe)
        {
            await _repository.UpdateAsync(recipe);
        }
        public async Task DeleteRecipe(int id)
        {
            await _repository.DeleteAsync(id);
        }

        #endregion
    }
}
