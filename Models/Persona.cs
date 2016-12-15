using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Publicaciones.Models
{
    public class Persona
    {
        [Key]
        /// <summary>
        /// Rut de la persona.
        /// </summary>
        /// <returns></returns>
        public string Rut { get; set; }

        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        /// <returns></returns>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido de la persona.
        /// </summary>
        /// <returns></returns>
        public string Apellido { get; set; }
        
    }

    public class Publicacion
    {
        [Key]
        /// <summary>
        /// Identificador de la publicacion.
        /// </summary>
        /// <returns></returns>
        public int IdPublicacion { get; set; }

        /// <summary>
        /// Titulo de la publicacion.
        /// </summary>
        /// <returns></returns>
        public string Titulo { get; set; }

        /// <summary>
        /// Fecha de inicio de la publicacion, desde que se comenzo a escribir.
        /// </summary>
        /// <returns></returns>
        public string FechaInicio { get; set; }

        /// <summary>
        /// Fecha de termino de la publicacion, momento en el que fue publicada e indizada 
        /// </summary>
        /// <returns></returns>
        public string FechaTermino { get; set; }

        /// <summary>
        /// Abstract (resumen) de la publicacion.
        /// </summary>
        /// <returns></returns>
        public string Abstract { get; set; }

        /// <summary>
        /// Linea investigativa de la publicacion.
        /// </summary>
        /// <returns></returns>
        public string LineaInvestigativa { get; set; }

        /// <summary>
        /// Area de desarrollo de la investigacion.
        /// </summary>
        /// <returns></returns>
        public string AreaDesarrollo { get; set; }
        
    }

    public class Autor
    {
        public string Fecha { get; set; }
        
        public int IdPublicacion { get; set; }

        public string IdPersona { get; set; }

    }
}