using ToDoList.Models;

namespace ToDoList.Interfaces
{
    public interface IRepositorio
    {
        Tarefa InsertTarefa(Tarefa tarefa);
        List<Tarefa> GetAllTarefas();
        void DeleteTarefa(int id);
        Tarefa UpdateTarefa(Tarefa tarefa);
    }
}
