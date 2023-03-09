using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateAPI.Domain.Entities;

namespace TemplateAPI.SQL.Mappings
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasMany(x => x.Responsaveis)
                .WithMany(r => r.Pacientes);

            builder.OwnsOne(x => x.CPF, p =>
            {
                p.Property(c => c.Value).HasColumnName("CPF");
            });

            builder.HasOne(x => x.Endereco)
                .WithOne(e => e.Paciente)
                .HasForeignKey<Endereco>(e => e.IdPaciente);
            

        }
    }
}
