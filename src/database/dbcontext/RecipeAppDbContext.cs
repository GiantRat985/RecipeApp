using Microsoft.EntityFrameworkCore;

namespace RecipeApp
{
    public class RecipeAppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<RecipeHtml> RecipesHtmlFormat { get; set; }
    }
}
