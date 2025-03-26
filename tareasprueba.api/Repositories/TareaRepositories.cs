using tareasprueba.api.Interfaces;
using tareasprueba.api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
namespace tareasprueba.api.Repositories
{
    public class TareaRepositories : ITareasRepositories
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public TareaRepositories(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _context = context;
        }
        public async Task<int> CreateTarea(Tarea tarea)
        {
            var escalar = await _context.escalarValues
       .FromSqlInterpolated($"EXEC SP_TAREA @ACCION = 'I', @ID_ESTADO ={tarea.id_estado}, @NOMBRE_TAREA ={tarea.nombre_tarea}")
       .ToArrayAsync();

            return escalar[0].Value;
        }

        public async Task<int> DeleteTarea(Tarea tarea)
        {
            var escalar = await _context.escalarValues
       .FromSqlInterpolated($"EXEC SP_TAREA @ACCION = 'D', @ID_TAREA ={tarea.id}")
       .ToArrayAsync();

            return escalar[0].Value;
        }



        public async Task<int> EditTarea(Tarea tarea)
        {
            var escalar = await _context.escalarValues
         .FromSqlInterpolated($"EXEC SP_TAREA @ACCION = 'U', @ID_TAREA ={tarea.id}, @ID_ESTADO = {tarea.id_estado},@NOMBRE_TAREA = {tarea.nombre_tarea}")
         .ToArrayAsync();
            return escalar[0].Value;
           
        }

        public async Task<List<Tarea>> GetTareas()
        {
            return await _context.tareas
            .FromSqlInterpolated($"EXEC SP_TAREA @ACCION = 'C1'")
            .ToListAsync();
        }

        public async Task<List<Tarea>> GetTareasId(Tarea tarea)
        {
            return await _context.tareas
         .FromSqlInterpolated($"EXEC SP_TAREA @ACCION = 'C', @ID_TAREA ={tarea.id}")
         .ToListAsync();
        }

        public  async Task<List<Tarea_estado>> ListaEstadoTarea()
        {
            return await _context.tarea_Estados
        .FromSqlInterpolated($"EXEC SP_LISTA_ESTADO")
        .ToListAsync();
        }
    }
}
