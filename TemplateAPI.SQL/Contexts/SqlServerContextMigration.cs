using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateAPI.SQL.Contexts
{
    public class SqlServerContextMigration : IDesignTimeDbContextFactory<SqlServerContext>
    {
        /// <summary>
        /// Injetor de depend�ncia para a classe SqlServerContext sempre que executarmos
        /// o recurso do Migrations do EntityFramework
        /// </summary>
        public SqlServerContext CreateDbContext(string[] args)
        {
            #region Localizar o arquivo appsettings.json

            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            #endregion

            #region Capturar a connectionstring do arquivo appsettings.json

            var root = configurationBuilder.Build();
            var connectionString = root.GetSection("ConnectionStrings").GetSection("Clinica").Value;

            #endregion

            #region Fazer a inje��o de depend�ncia na classe SqlServerContext

            var builder = new DbContextOptionsBuilder<SqlServerContext>();
            builder.UseSqlServer(connectionString);

            return new SqlServerContext(builder.Options);

            #endregion
        }
    }
}
