using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NoteApp.DbContexts
{
    public class NoteAllDesignTimeDbContextFactory : IDesignTimeDbContextFactory<NoteAppDbContext>
    {
        public NoteAppDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=noteapp.db").Options;

            return new NoteAppDbContext(options);
        }
    }
}
