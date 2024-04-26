namespace RecipeApp
{
    public interface IRecipeDeleter
    {
        public Task DeleteRecipe(int id);
    }
}
