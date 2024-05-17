using Microsoft.EntityFrameworkCore;

namespace RecipeApp
{
    public class RecipeRepository<T> : IRepository<T> where T : class
    {
        private readonly RecipeAppDbContextFactory _dbContextFactory;
        private readonly DbSet<T> _dbSet;

        public RecipeRepository(RecipeAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using var context = _dbContextFactory.CreateDbContext();
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Adds an entity to the database as an asynchronous operation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task AddAsync(T item)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await _dbSet.AddAsync(item);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Finds entity with given ID and marks it for deletion as an asynchronous operation.
        /// </summary>
        /// <param name="id">ID of the entity to be marked for deletion.</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var item = _dbSet.Find(id);
            if (item == null)
            {
                return;
            }
            context.Remove(item);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all entities in the <see cref="DbSet{T}"/> asynchronously.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of the corresponding type.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Gets a specific entity using its ID asynchronously.
        /// </summary>
        /// <param name="id">ID of the desired entity.</param>
        /// <returns>An object of type <see cref="Type"/></returns>
        public async Task<T> GetAsync(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var item = await _dbSet.FindAsync(id);
            if (item == null)
            {
                return null;
            }
            return item;
        }

        /// <summary>
        /// Updates database entity with new data as an asynchronous operation.
        /// </summary>
        /// <param name="item">Item to be updated.</param>
        /// <returns></returns>
        public async Task UpdateAsync(T item)
        {
            using var context = _dbContextFactory.CreateDbContext();
            _dbSet.Attach(item);
            await context.SaveChangesAsync();
        }
    }
}
