using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Interfaces.Repositories;
using TemplateAPI.SQL.Contexts;

namespace TemplateAPI.SQL.Repositories
{
    public class PacienteRepository : Repository<Paciente, Guid>, IPacienteRepository
    {
        public PacienteRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
        }
    }
}
