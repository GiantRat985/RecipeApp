namespace RecipeApp
{
    /// <summary>
    /// Holds information about a recipe.
    /// </summary>
    public class Recipe(string title, string? url, string? description, string? body, byte[]? thumbnail)
    {
        /// <summary>
        /// Recipe title.
        /// </summary>
        public string Title { get; } = title;
        /// <summary>
        /// Holds the URL for a recipe if the recipe is gathered from the internet.
        /// </summary>
        public string? URL { get; } = url;
        /// <summary>
        /// Description of the recipe; time to cook, servings, summary.
        /// </summary>
        public string? Description { get; } = description;
        /// <summary>
        /// Main body of the recipe; directions, ingredients, notes.
        /// </summary>
        public string? Body { get; } = body;
        /// <summary>
        /// Optional thumbnail image, saved as a byte array.
        /// </summary>
        public byte[]? Thumbnail { get; } = thumbnail;
    }
}
