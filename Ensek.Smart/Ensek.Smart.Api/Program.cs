using Ensek.Smart.Data;
using Microsoft.EntityFrameworkCore;
using Ensek.Smart.Api.Service;

namespace Ensek.Smart.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("SmartDatabase");

            builder.Services.AddControllers();
            builder.Services.AddDbContext<SmartDatabaseContext>(opts => opts.UseSqlServer(connectionString));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICsvService, CsvService>();

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