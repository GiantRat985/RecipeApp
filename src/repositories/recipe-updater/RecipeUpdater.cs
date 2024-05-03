using Microsoft.EntityFrameworkCore;

namespace RecipeApp
{
    public class RecipeUpdater(RecipeAppDbContextFactory dbContextFactory) : IRecipeUpdater
    {
        private readonly RecipeAppDbContextFactory _dbContextFactory = dbContextFactory;

        public async Task UpdateDatabase(IRecipe recipe)
        {
            var updatedRecipe = DTOConverter.ConvertToDTO(recipe);
            using var context = _dbContextFactory.CreateDbContext();
            context.Recipes.Attach(updatedRecipe);
            context.Entry(updatedRecipe).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
