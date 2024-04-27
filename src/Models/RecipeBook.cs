namespace RecipeApp
{
    public class RecipeBook(IRecipeCreator recipeCreator, IRecipeProvider recipeProvider, IRecipeUpdater recipeUpdater, IRecipeDeleter recipeDeleter)
    {
        private readonly IRecipeCreator _recipeCreator = recipeCreator;
        private readonly IRecipeProvider _recipeProvider = recipeProvider;
        private readonly IRecipeUpdater _recipeUpdater = recipeUpdater;
        private readonly IRecipeDeleter _recipeDeleter = recipeDeleter;

        public async Task CreateEntry(IRecipe recipe)
        {
            await _recipeCreator.CreateRecipe(recipe);
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllEntries()
        {
            return await _recipeProvider.GetAllRecipes();
        }

        public async Task UpdateEntry(IRecipe recipe)
        {
            await _recipeUpdater.UpdateDatabase(recipe);
        }

        public async Task DeleteEntry(int id)
        {
            await _recipeDeleter.DeleteRecipe(id);
        }
    }
}
