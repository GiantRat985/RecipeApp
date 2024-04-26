namespace RecipeApp
{
    public interface IRecipeCreator
    {
        public Task CreateRecipe(IRecipe recipe);
    }
}
