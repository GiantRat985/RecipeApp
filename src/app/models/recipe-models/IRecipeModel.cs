using System.Security.Policy;

namespace RecipeApp
{
    public interface IRecipeModel
    {
        public DateTime DateAdded { get; }
        public string Content { get; }
    }
}
