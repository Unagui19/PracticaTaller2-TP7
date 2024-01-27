using ManejoDeDatos;
using Entidades;

namespace Entidades
{
    public class ManejoTareas
    {
        public List<Tarea> Tareas {get; set;}
        // public int CantidadDeTareas {get; set;}
        public AccesoDatos HelperJson {get; set;}

        public ManejoTareas(){
            // CantidadDeTareas = 0 ;
            Tareas = new List<Tarea>();
            HelperJson = new AccesoDatos();
        }

        public bool CrearTarea(string titulo, string descripcion){
            Tareas = HelperJson.GetTareas();
            // CantidadDeTareas++;
            Tarea nuevaTarea = new Tarea(Tareas.Count, titulo, descripcion);
            if (nuevaTarea != null)
            {
                Tareas.Add(nuevaTarea);
                HelperJson.guardarTarea(Tareas);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Tarea BuscarTareaPorId(int idTarea){
            Tareas = HelperJson.GetTareas();
            Tarea tareaBuscada = Tareas.FirstOrDefault( tarea => tarea.Id == idTarea);
            if (tareaBuscada != null)
            {
                return tareaBuscada;
            }
            else
            {
                return null;
            }
        }

        public void ActualizarTarea(int idTarea, string titulo, string descripcion, Estado estado){
            Tareas = HelperJson.GetTareas();
            Tarea tareaBuscada = BuscarTareaPorId(idTarea);
            if (tareaBuscada != null)
            {
                tareaBuscada.Titulo = titulo;
                tareaBuscada.Descripcion = descripcion;
                tareaBuscada.Estado = estado;
                HelperJson.guardarTarea(Tareas);
            }
        }

        public void BorrarTaraea(int idTarea){
            Tareas = HelperJson.GetTareas();
            Tarea tareaBuscada = BuscarTareaPorId(idTarea);
            if (tareaBuscada != null)
            {
                Tareas.Remove(tareaBuscada);
                HelperJson.guardarTarea(Tareas);
            }
        }
    }

}