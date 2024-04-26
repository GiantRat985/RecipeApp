namespace RecipeApp
{
    public class RecipeDTO : IRecipeDTO
    {
        public int ID { get; set; }
        public string Title { get; set; } = null!;
        public string? URL { get; set; }
        public string? Description { get; set; }
        public string? Body { get; set; }
        public byte[]? Thumbnail { get; set; }
    }
}
