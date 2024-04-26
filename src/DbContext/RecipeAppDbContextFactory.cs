using Microsoft.EntityFrameworkCore;

namespace RecipeApp
{
    public class RecipeAppDbContextFactory
    {
        private readonly string _connectionString;

        public RecipeAppDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public RecipeAppDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new RecipeAppDbContext(options);
        }
    }
}
