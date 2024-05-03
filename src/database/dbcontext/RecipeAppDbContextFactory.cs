using Microsoft.EntityFrameworkCore;

namespace RecipeApp
{
    public class RecipeAppDbContextFactory(string connectionString)
    {
        private readonly string _connectionString = connectionString;

        public RecipeAppDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new RecipeAppDbContext(options);
        }
    }
}
