using Microsoft.EntityFrameworkCore;
using Lista_de_Tarefas.Data;
using Lista_de_Tarefas.Repositories.Interfaces;
using Lista_de_Tarefas.Repositories;

namespace Lista_de_Tarefas
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal"));
            });

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}