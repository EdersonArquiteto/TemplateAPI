using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Interfaces.Repositories;
using TemplateAPI.SQL.Contexts;

namespace TemplateAPI.SQL.Repositories
{
    public class EnderecoRepository : Repository<Endereco, Guid>, IEnderecoRepository
    {
        public EnderecoRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
        }
    }
}
