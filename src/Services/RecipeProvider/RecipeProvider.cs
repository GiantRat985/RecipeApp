using Microsoft.EntityFrameworkCore;

namespace RecipeApp
{
    public class RecipeProvider(RecipeAppDbContextFactory dbContextFactory)
    {
        private readonly RecipeAppDbContextFactory _dbContextFactory = dbContextFactory;

        public async Task<List<RecipeDTO>> GetAllRecipes()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.Recipes.ToListAsync();
        }
    }
}
