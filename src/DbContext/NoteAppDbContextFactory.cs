using Microsoft.EntityFrameworkCore;

namespace NoteApp.DbContexts
{
    public class NoteAppDbContextFactory
    {
        private readonly string _connectionString;

        public NoteAppDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NoteAppDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new NoteAppDbContext(options);
        }
    }
}
