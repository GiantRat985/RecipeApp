namespace RecipeApp
{
    public interface IRecipeBook
    {
        public Task CreateEntry(IRecipe recipe);
        public Task<IEnumerable<RecipeDTO>> GetAllEntries();
        public Task UpdateEntry(IRecipe recipe);
        public Task DeleteEntry(int id);
    }
}
