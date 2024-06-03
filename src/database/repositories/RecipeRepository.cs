using Microsoft.EntityFrameworkCore;

namespace RecipeApp
{
    /// <summary>
    /// Repository class to handle CRUD functions.
    /// </summary>
    /// <typeparam name="TRecipeModel">a <see cref="RecipeModelBase"/> type that will be
    /// set as the type of the DbSet</typeparam>
    public class RecipeRepository
    {
        private readonly RecipeAppDbContextFactory _dbContextFactory;

        public RecipeRepository(RecipeAppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Adds an entity to the database as an asynchronous operation.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task AddAsync(RecipeData item)
        {
            using var context = _dbContextFactory.CreateDbContext();
            await context.RecipeSet.AddAsync(item);
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
            var item = context.RecipeSet.Find(id);
            if (item == null)
            {
                return;
            }
            context.RecipeSet.Remove(item);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all entities in the <see cref="DbSet{T}"/> asynchronously.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of the corresponding type.</returns>
        public async Task<IEnumerable<RecipeData>> GetAllAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.RecipeSet.ToListAsync();
        }

        /// <summary>
        /// Gets a specific entity using its ID asynchronously.
        /// </summary>
        /// <param name="id">ID of the desired entity.</param>
        /// <returns>An object of type <see cref="Type"/></returns>
        public async Task<RecipeData> GetAsync(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var item = await context.RecipeSet.FindAsync(id);

            if (item == null)
            {
                throw new NullReferenceException($"Entity ID:{id} could not be found.");
            }

            return item;
        }

        /// <summary>
        /// Updates database entity with new data as an asynchronous operation.
        /// </summary>
        /// <param name="item">Item to be updated.</param>
        /// <returns></returns>
        public async Task UpdateAsync(RecipeData item)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.RecipeSet.Attach(item);
            await context.SaveChangesAsync();
        }
    }
}
