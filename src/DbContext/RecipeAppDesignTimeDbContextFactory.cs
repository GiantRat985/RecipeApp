using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RecipeApp
{
    public class RecipeAppDesignTimeDbContextFactory : IDesignTimeDbContextFactory<RecipeAppDbContext>
    {
        public RecipeAppDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=recipeapp.db").Options;

            return new RecipeAppDbContext(options);
        }
    }
}
