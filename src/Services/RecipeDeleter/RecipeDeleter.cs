
namespace RecipeApp
{
    public class RecipeDeleter(RecipeAppDbContextFactory dbContextFactory) : IRecipeDeleter
    {
        private readonly RecipeAppDbContextFactory _dbContextFactory = dbContextFactory;

        public async Task DeleteRecipe(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var emptyDTO = DTOConverter.CreateEmptyDTO(id);
            context.Remove(emptyDTO);
            await context.SaveChangesAsync();
        }
    }
}
