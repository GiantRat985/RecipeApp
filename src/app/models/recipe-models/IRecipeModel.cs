using System.Security.Policy;

namespace RecipeApp
{
    public interface IRecipeModel
    {
        /// <summary>
        /// Main database key.
        /// </summary>
        public int ID { get; }
        public string Title { get; }
        public DateTime DateAdded { get; }
    }
}
