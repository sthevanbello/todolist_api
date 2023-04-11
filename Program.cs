using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ToDoList.Context;
using ToDoList.Interfaces;
using ToDoList.Repositorios;

namespace ToDoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TodoList",
                    Version = "v1",
                    Description = "Projeto de conclusão de curso - Software Product",
                    Contact = new OpenApiContact()
                    {
                        Name = "Repositório do código completo",
                        Url = new Uri("https://github.com/raphaelmelo/projeto-final")
                    }
                });
                var xmlArquivo = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlArquivo));
            });


            builder.Services.AddDbContext<TarefaDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("Render"), 
                    m => m.MigrationsAssembly("ToDoListApi"));
            });

            builder.Services.AddScoped<IRepositorio, Repositorio>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TarefaDbContext>();
                db.Database.Migrate();
            }


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
        }
    }
}