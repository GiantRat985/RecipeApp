namespace RecipeApp
{
    public interface IRecipeUpdater
    {
        public Task UpdateDatabase(IRecipe recipe);
    }
}
