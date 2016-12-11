namespace Publicaciones.Models
{
    public class Persona
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
    
    }

    public class Publicacion
    {

        public string Titulo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public string Abstract { get; set; }
        public string LineaInvestigativa { get; set; }
        public string AreaDesarrollo { get; set; }

    }
}