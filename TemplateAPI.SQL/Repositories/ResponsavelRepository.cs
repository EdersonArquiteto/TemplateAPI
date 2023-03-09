using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Interfaces.Repositories;
using TemplateAPI.SQL.Contexts;

namespace TemplateAPI.SQL.Repositories
{
    public class ResponsavelRepository : Repository<Responsavel, Guid>, IResponsavelRepository
    {
        public ResponsavelRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
        }
    }
}
