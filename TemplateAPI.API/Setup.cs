using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TemplateAPI.Application.Interfaces;
using TemplateAPI.Application.Services;
using TemplateAPI.Domain.Interfaces.Repositories;
using TemplateAPI.Domain.Interfaces.Services;
using TemplateAPI.Domain.Services;
using TemplateAPI.SQL.Contexts;
using TemplateAPI.SQL.Repositories;

namespace TemplateAPI.API
{
    public static class Setup
    {
        public static void AddRegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IPacienteAppService, PacienteAppService>();
            
            builder.Services.AddTransient<PacienteDomainService>();
            builder.Services.AddTransient<EnderecoDomainService>();
            builder.Services.AddTransient<ResponsavelDomainService>();
            //builder.Services.AddTransient<ITarefaDomainService, TarefaDomainService>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Clinica");
            builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddAutoMapperServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
           
        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Gestão de Consultas",
                    Description = "API REST Gestão de Consultas",
                    Contact = new OpenApiContact { Name = "TheONe Software", Email = "contato@theonesoftware.com.br", Url = new Uri("http://www.theonesoftware.com.br") }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }
        public static void AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                   s => s.AddPolicy("DefaultPolicy", builder =>
                   {
                       builder.AllowAnyOrigin() //qualquer origem pode acessar a API
                              .AllowAnyMethod() //qualquer método (POST, PUT, DELETE, GET)
                              .AllowAnyHeader(); //qualquer informação de cabeçalho
                   })
               );
        }
        public static void UseCors(this WebApplication app)
        {
            app.UseCors("DefaultPolicy");
        }

        
       
        

    }
}
