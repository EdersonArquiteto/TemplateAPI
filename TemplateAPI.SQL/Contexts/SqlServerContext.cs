using Microsoft.EntityFrameworkCore;
using TemplateAPI.Domain.Entities;

namespace TemplateAPI.SQL.Contexts
{
    public class SqlServerContext : DbContext
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="dbContextOptions">Classe do EF para opções de configuração do DbContext</param>
        public SqlServerContext(DbContextOptions<SqlServerContext> dbContextOptions) : base(dbContextOptions) { }

        /// <summary>
        /// Propriedade para fornecer os métodos que serão
        /// utilizados no repositório de usuários
        /// </summary>
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }

        /// <summary>
        /// Método para adicionar cada classe de mapeamento
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
