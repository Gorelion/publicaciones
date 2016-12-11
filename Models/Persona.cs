using System.Collections.Generic;
namespace Publicaciones.Models
{
    public class Persona
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
        
        public List<Autor> Autores { get; set; }
    }

    public class Publicacion
    {
        public int IdAutor { get; set; }
        public string Titulo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public string Abstract { get; set; }
        public string LineaInvestigativa { get; set; }
        public string AreaDesarrollo { get; set; }
        
    }

    public class Autor
    {
        public string Fecha { get; set; }
        public int IdPublicacion { get; set; }

    }
}