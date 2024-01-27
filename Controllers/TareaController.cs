using Microsoft.AspNetCore.Mvc;
using Entidades;
using Microsoft.AspNetCore.Http.HttpResults;
using ManejoDeDatos;


namespace TP7.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{

    private readonly ILogger<TareaController> _logger;
    private ManejoTareas manejoTareas;
    private AccesoDatos accesoDatos;


    public TareaController(ILogger<TareaController> logger)
    {
        manejoTareas = new ManejoTareas();
        accesoDatos = new AccesoDatos();
        _logger = logger;
    }

//     ● Crear una nueva tarea.
    [HttpPost]// post esta bueno para crear algo nuevo
    [Route ("CrearTarea")]
    public ActionResult<bool> CrearTarea(string titulo, string descripcion){
        bool resultado = manejoTareas.CrearTarea(titulo,descripcion);
        if (resultado)
        {
            return Ok("Tarea agregada cone éxito");
        }
        else
        {
            return BadRequest("No se pudo agregar la tarea deseada");
        }
    }
// ● Obtener una tarea por id.
    [HttpGet]
    [Route ("Obtener tarea")]
    public ActionResult<Tarea> GetTareaPorId(int idTarea){
        return manejoTareas.BuscarTareaPorId(idTarea);
    }
// ● Actualizar una tarea.
    [HttpPut]//put para actualizar algo
    [Route ("Update Tarea")]
    public ActionResult<Tarea> UpdateTarea(int idTarea, string titulo, string descripcion, Estado estado){
        if (manejoTareas.BuscarTareaPorId(idTarea) != null)
        {
            manejoTareas.ActualizarTarea(idTarea, titulo, descripcion, estado);
            return Ok("Tarea actualizada con exito");
        }
        else
        {
            return BadRequest("Tarea no encontrada");
        }
    }
// ● Eliminar una tarea.
    [HttpDelete]//put para actualizar algo
    [Route ("Delete Tarea")]
    public ActionResult<Tarea> DeleteTarea(int idTarea){
        if (manejoTareas.BuscarTareaPorId(idTarea) != null)
        {
            manejoTareas.BorrarTaraea(idTarea);
            return Ok("Tarea Borrada con exito");
        }
        else
        {
            return BadRequest("Tarea no encontrada");
        }
    }

// ● Listar todas las tareas.
    [HttpGet]
    [Route ("Listar Tareas")]
    public ActionResult<IEnumerable<Tarea>> ListarTareas(){
        List<Tarea> tareas = accesoDatos.GetTareas();
        if (tareas != null)
        {
            return Ok(tareas);        
        }
        else
        {
            return StatusCode(500,"No hay tareas");
        }
    }

// ● Listar todas las tareas completadas.
    [HttpGet]
    [Route ("Listar Tareas Completadas")]
    public ActionResult<IEnumerable<Tarea>> ListarTareasCompletadas(){
        List<Tarea> tareas = accesoDatos.GetTareas();
        if (tareas != null)
        {
            List<Tarea> tareasCompletadas = tareas.FindAll(tarea => tarea.Estado == Estado.Completada);
            if (tareasCompletadas != null)
            {
                return Ok(tareasCompletadas);        
            }        
            else
            {
                return BadRequest("No hay tareas completadas");
            }
        }
        else
        {
            return BadRequest("No hay tareas");
        }
    }
    
}
