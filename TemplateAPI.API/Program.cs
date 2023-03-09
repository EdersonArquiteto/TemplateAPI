using TemplateAPI.API;
using TemplateAPI.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Setup.AddSwagger(builder);
Setup.AddCors(builder);
Setup.AddRegisterServices(builder);
Setup.AddEntityFrameworkServices(builder);
Setup.AddAutoMapperServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

Setup.UseCors(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//Declara��o publica da classe
public partial class Program { }
