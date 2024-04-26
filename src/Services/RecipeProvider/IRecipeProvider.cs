namespace RecipeApp
{
    public interface IRecipeProvider
    {
        public Task<List<RecipeDTO>> GetAllRecipes();
    }
}
