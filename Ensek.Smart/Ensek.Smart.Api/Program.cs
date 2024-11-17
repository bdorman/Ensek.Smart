using Ensek.Smart.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ensek.Smart.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);           

            builder.Services.AddControllers();

            var connectionString = builder.Configuration.GetConnectionString("SmartDatabase");
            builder.Services.AddDbContextFactory<SmartDatabaseContext>(o => o.UseSqlServer(connectionString), ServiceLifetime.Scoped);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}