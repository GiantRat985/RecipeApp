namespace RecipeApp
{
    public interface IModelFactory
    {
        public IRecipeModel CreateRecipeModel(string content);
    }
}