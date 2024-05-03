namespace RecipeApp
{
    public class RecipeCreator(RecipeAppDbContextFactory dbContextFactory) : IRecipeCreator
    {
        private readonly RecipeAppDbContextFactory _dbContextFactory = dbContextFactory;

        public async Task CreateRecipe(IRecipe recipe)
        {
            var recipeDTO = DTOConverter.ConvertToDTO(recipe);
            using var context = _dbContextFactory.CreateDbContext();
            await context.Recipes.AddAsync(recipeDTO);
            await context.SaveChangesAsync();
        }


    }
}
