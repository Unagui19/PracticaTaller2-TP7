namespace Entidades
{
    public enum Estado {Pendiente , EnProgreso, Completada }
    public class Tarea
    {
        public int Id{ get; set;}
        public string Titulo {get; set;}
        public string Descripcion {get; set;}
        public Estado Estado {get; set;}

//----------CONSTRUCTORES------------
        public Tarea(int id, string titulo, string descripcion)
        {
            Id = id+1;
            Titulo = titulo;
            Descripcion = descripcion;
            Estado = Estado.Pendiente;
        }

        public Tarea(){

        }

//----------METODOS------------

        


    }    
}