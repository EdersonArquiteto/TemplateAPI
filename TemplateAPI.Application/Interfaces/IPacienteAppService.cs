using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAPI.Application.DTOs;

namespace TemplateAPI.Application.Interfaces
{
    public interface IPacienteAppService
    {
        Task CriarPaciente(PacienteDTO pacienteDTO);
    }
}
