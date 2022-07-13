using Microsoft.EntityFrameworkCore;
using RepositoryUoW.Business.Interfaces;
using RepositoryUoW.Business.Services;
using RepositoryUoW.Data.Context;
using RepositoryUoW.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<RepositoryUoWContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RepositoryUoWConStr")));

builder.Services.AddScoped<RepositoryUoWContext>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Development",
        builder => 
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
