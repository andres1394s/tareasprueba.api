using tareasprueba.api.Models;

namespace tareasprueba.api.Interfaces
{
    public interface ITareasRepositories
    {
       public  Task<List<Tarea>> GetTareas();
       public  Task<List<Tarea>> GetTareasId(Tarea tarea);
       public  Task<int> EditTarea(Tarea tarea);
       public  Task<int> CreateTarea(Tarea tarea);
       public  Task<int> DeleteTarea(Tarea tarea);
       public  Task<List<Tarea_estado>> ListaEstadoTarea();
    }
}
