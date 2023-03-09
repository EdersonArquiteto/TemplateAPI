using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAPI.Domain.Core;
using TemplateAPI.Domain.Entities;

namespace TemplateAPI.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository : IRepository<Endereco, Guid>
    {
    }
}
