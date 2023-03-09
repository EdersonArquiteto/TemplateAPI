using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateAPI.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        IEnderecoRepository EnderecoRepository { get; }
        IPacienteRepository PacienteRepository { get; }
        IResponsavelRepository ResponsavelRepository { get; }
    }
}
