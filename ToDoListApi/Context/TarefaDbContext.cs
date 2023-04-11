using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Context
{
    public class TarefaDbContext : DbContext
    {
        public TarefaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
