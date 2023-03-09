using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateAPI.Domain.Entities;

namespace TemplateAPI.SQL.Mappings
{
    public class ResponsavelMap : IEntityTypeConfiguration<Responsavel>
    {
        public void Configure(EntityTypeBuilder<Responsavel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.OwnsOne(x => x.Email, p =>
            {
                p.Property(e => e.Value).HasColumnName("Email");
            });

            builder.OwnsOne(x => x.Telefone, p =>
            {
                p.Property(e => e.Value).HasColumnName("Telefone");
            });

            builder.OwnsOne(x => x.Celular, p =>
            {
                p.Property(e => e.Value).HasColumnName("Celular");
            });

            builder.OwnsOne(x => x.CPF, p =>
            {
                p.Property(e => e.Value).HasColumnName("CPF");
            });
            
        }
    }
}
