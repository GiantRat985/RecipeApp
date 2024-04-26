using System.Security.Policy;

namespace RecipeApp
{
    public interface IRecipeDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string? URL { get; set; }
        public string? Description { get; set; }
        public string? Body { get; set; }
        public byte[]? Thumbnail { get; set; }
    }
}
