using Cobranca.Domain.Repository;
using Cobranca.InfraStructure.Context;
using Cobranca.InfraStructure.Repositories;
using Cobranca.Service.Interface;
using Cobranca.Service.Mapping;
using Cobranca.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("CobrancaDB");

builder.Services.AddDbContext<CobrancaContext>(options =>
        options.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=cobranca;User Id=postgres;Password=123456;"));


builder.Services.AddTransient<IBancoService, BancoService>();
builder.Services.AddTransient<IBancoRepository, BancoRepository>();

builder.Services.AddTransient<IBoletoService, BoletoService>();
builder.Services.AddTransient<IBoletoRepository, BoletoRepository>();



#region Profile
var profile = new MappingProfile();
builder.Services.AddAutoMapper(s => s.AddProfile(profile));
#endregion



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
