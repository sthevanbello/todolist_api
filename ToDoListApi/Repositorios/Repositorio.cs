using ToDoList.Context;
using ToDoList.Interfaces;
using ToDoList.Models;

namespace ToDoList.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly TarefaDbContext _context;
        public Repositorio(TarefaDbContext context)
        {
            _context = context;
        }
        public void DeleteTarefa(int id)
        {
            Tarefa tarefa = new Tarefa { Id = id };

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
        }

        public List<Tarefa> GetAllTarefas()
        {
            var tarefas = _context.Tarefas.ToList();
            return tarefas;
        }

        public Tarefa InsertTarefa(Tarefa tarefa)
        {
            Tarefa retorno = _context.Tarefas.Add(tarefa).Entity;
            _context.SaveChanges();
            return retorno;
        }

        public Tarefa UpdateTarefa(Tarefa tarefa)
        {
            var retorno = _context.Tarefas.Update(tarefa).Entity;
            _context.SaveChanges();
            return retorno;
        }
    }
}
