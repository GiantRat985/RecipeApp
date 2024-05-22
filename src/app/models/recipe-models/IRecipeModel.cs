using System.Security.Policy;

namespace RecipeApp
{
    public interface IRecipeModel
    {
        /// <summary>
        /// Main database key.
        /// </summary>
        public int ID { get; }
        public DateTime DateAdded { get; }
        public string Content { get; }
    }
}
