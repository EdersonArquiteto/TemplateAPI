using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAPI.Domain.Entities;

namespace TemplateAPI.Application.Mappings
{
    public class PacienteDTOToEntity : Profile
    {
        public PacienteDTOToEntity()
        {
            CreateMap<PacienteDTOToEntity, Paciente>()
                .AfterMap((command, entity) =>
                {
                    entity.Id = Guid.NewGuid();
                    entity.DataCadastro = DateTime.Now;
                });
        }
    }
}
