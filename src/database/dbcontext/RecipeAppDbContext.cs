using Microsoft.EntityFrameworkCore;

namespace RecipeApp
{
    public class RecipeAppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<RecipeModelHtml> RecipesHtmlFormat { get; set; }
    }
}
