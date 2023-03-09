using Microsoft.EntityFrameworkCore;
using TemplateAPI.Domain.Core;
using TemplateAPI.SQL.Contexts;

namespace TemplateAPI.SQL.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        protected Repository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public async Task Create(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Added;
            _sqlServerContext.SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Deleted;
            _sqlServerContext.SaveChanges();
        }

        public async Task<TEntity> Get(TKey id)
        {
            return _sqlServerContext.Set<TEntity>().Find(id);
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return _sqlServerContext.Set<TEntity>().ToList();
        }


    }
}
