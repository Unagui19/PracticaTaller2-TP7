using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Serialization;
using Entidades;

namespace ManejoDeDatos
{
    public class AccesoDatos
    {
        public List<Tarea> GetTareas()
        {
            try
            {
                string filePath = "Data/tareas.json";

                if (!File.Exists(filePath))
                {
                    // Si el archivo no existe, lo crea con un array JSON vacío.
                    File.WriteAllText(filePath, "[]");
                }

                string textoJson = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(textoJson))
                {
                    // Si el archivo está vacío o contiene solo espacios en blanco, retorna una lista vacía.
                    return new List<Tarea>();
                }

                return JsonSerializer.Deserialize<List<Tarea>>(textoJson) ?? new List<Tarea>();
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones aquí según sea necesario.
                Console.WriteLine($"Error al obtener tareas: {ex.Message}");
                return new List<Tarea>();
            }
        }

        public void guardarTarea(List<Tarea> tareas)
        {    
            var fst = new FileStream("Data/tareas.json",FileMode.OpenOrCreate);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string archivoJson = JsonSerializer.Serialize(tareas, options);
            using (var sw =new StreamWriter(fst))
            {
                sw.WriteLine(archivoJson);
                sw.Close();
            }//PARA CREAR UN JSON y guardar o solo guardar 
            fst.Close();
        }

    }
}