using System.Security.Policy;

namespace RecipeApp
{
    public interface IRecipe
    {
        /// <summary>
        /// Recipe title.
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// Holds the URL for a recipe if the recipe is gathered from the internet.
        /// </summary>
        public string? URL { get; }
        /// <summary>
        /// Description of the recipe; time to cook, servings, summary.
        /// </summary>
        public string? Description { get; }
        /// <summary>
        /// Main body of the recipe; directions, ingredients, notes.
        /// </summary>
        public string? Body { get; }
        /// <summary>
        /// Optional thumbnail image, saved as a byte array.
        /// </summary>
        public byte[]? Thumbnail { get; }
    }
}
