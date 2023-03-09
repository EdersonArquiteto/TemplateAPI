using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateAPI.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity, TKey>
        where TEntity : class
    {
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        Task<IList<TEntity>> GetAll();
        Task<TEntity> Get(TKey id);
    }
}
