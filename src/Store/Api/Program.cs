
using Application;
using Microsoft.EntityFrameworkCore;
using Net6StudyCase.Auth.Api.DependencyInjection.BusinessRules;
using Net6StudyCase.Store.Infra.Database.Context;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("UsuarioConnection");

// Add services to the container.
builder.Services.AddDbContext<ProdutoDbContext>(opts => opts.UseMySql(
    connectionString,
    ServerVersion.AutoDetect(connectionString)
));

builder.Services.AddAutoMapper(typeof(ProdutoProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationConfiguration();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
