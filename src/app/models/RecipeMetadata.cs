namespace RecipeApp
{
    public class RecipeMetadata
    {
        public string? Title { get; set; }
        public string? Author { get; set; }

        public RecipeMetadata() { }
        public RecipeMetadata(string? title, string? author)
        {
            Title = title;
            Author = author;
        }
    }
}
