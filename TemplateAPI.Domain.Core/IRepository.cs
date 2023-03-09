namespace TemplateAPI.Domain.Core
{
    public interface IRepository<TEntity, TKey>
       where TEntity : class
    {
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        Task<IList<TEntity>> GetAll();
        Task<TEntity> Get(TKey id);
    }
}
