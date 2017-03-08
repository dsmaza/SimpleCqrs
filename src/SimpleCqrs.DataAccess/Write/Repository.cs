using System.Threading.Tasks;

namespace SimpleCqrs.DataAccess
{
    public class Repository<T> where T : class
    {
        protected readonly TestDbContext context;

        public Repository(TestDbContext context)
        {
            this.context = context;
        }

        public async Task Create(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> Find(params object[] keyValues)
            => await context.Set<T>().FindAsync(keyValues);

        public async Task Update(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
