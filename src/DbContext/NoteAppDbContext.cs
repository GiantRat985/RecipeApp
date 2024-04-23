using Microsoft.EntityFrameworkCore;

namespace NoteApp.DbContexts
{
    public class NoteAppDbContext(DbContextOptions options) : DbContext(options)
    {
    }
}
