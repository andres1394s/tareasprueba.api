using System.Threading;
using Microsoft.AspNetCore.Mvc;
using tareasprueba.api.Interfaces;
using tareasprueba.api.Models;


namespace tareasprueba.api.Controllers
{
    
    public class TareaController : ControllerBase
    {
        private readonly ITareasRepositories _tareasRepositories;
        public TareaController(ITareasRepositories tareasRepositories)
        {
            _tareasRepositories = tareasRepositories;
        }
        [HttpGet("GetAllTareas")]
        public async Task<IActionResult> GetAllTareas()
        {
            try
            {

                var tareas = await _tareasRepositories.GetTareas();
                return Ok(tareas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GetTareasId")]
        public async Task<IActionResult> GetTareasId([FromBody] Tarea tarea)
        {

            try
            {
                if (tarea.id == 0) return BadRequest("Debe enviar el id");

                var tareaedit = await _tareasRepositories.GetTareasId(tarea);
                if (tareaedit == null) return NotFound();

                return Ok(tareaedit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("DeleteTarea")]
        public async Task<IActionResult> DeleteTarea([FromBody] Tarea tarea)
        {
            try
            {

                var tareadelete = await _tareasRepositories.DeleteTarea(tarea);
                if (tareadelete == -1) return NotFound();

                return Ok(tareadelete);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateTarea")]
        public async Task<IActionResult> Create([FromBody] Tarea tarea)
        {
            try
            {
                var tareaCreada = await _tareasRepositories.CreateTarea(tarea);
                return Ok(tareaCreada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpPost("UpdateTarea")]
        public async Task<IActionResult> Update([FromBody] Tarea tarea)
        {
            try
            {

                var result = await _tareasRepositories.EditTarea(tarea);
                return result == -1 ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet("ListaTareaEstado")]
         public async Task<IActionResult> ListaTareaEstado()
        {
           var result =   await _tareasRepositories.ListaEstadoTarea();
            return Ok(result);
        }
    }
}

