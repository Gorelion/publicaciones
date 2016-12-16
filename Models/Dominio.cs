using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Publicaciones.Models
{   
    ///<summary>
    /// Clase que se encarga de representar a una Persona
    ///</summary>
    ///<returns></returns>
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
    ///<summary>
    /// Clase que se encarga de representar a una Publicacion
    ///</summary>
    ///<returns></returns>
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
    ///<summary>
    /// Clase que se encarga de representara un Autor (Se genera cuando Persona hace una Publicacion)
    ///</summary>
    ///<returns></returns>
    public class Autor
    {
        
        /// <summary>
        /// Fecha en que hizo la publicacion.
        /// </summary>
        // <returns></returns>
        public string Fecha { get; set; }
        
        /// <summary>
        /// Identificador unico de la publicacion.
        /// </summary>
        // <returns></returns>
        public int IdPublicacion { get; set; }

        /// <summary>
        /// Identificador de la persona responsable de la publicacion.
        /// </summary>
        // <returns></returns>
        public string IdPersona { get; set; }

    }
    
    ///<summary>
    /// Clase que se encarga de la creacion de la revista
    ///</summary>
    ///<returns></returns>
     public class Revista
     {
         /// <summary>
         /// Nombre de la revista
         /// </summary>
         // <returns></returns>
         public string Nombre { get; set; }
         
         /// <summary>
         /// Indice de la revista
         /// </summary>
         // <returns></returns>
         public string ISSN { get; set; }  
     }

    ///<summary>
    /// Clase que se encarga de indexar las revistas.
    ///</summary>
    ///<returns></returns>
    public class Indice
    {

       ///<summary>
       ///Identificador del indice.
       ///</summary>
       //<returns></returns>
       public int IdIndice { get; set; }

       ///<summary>
       ///Nombre del indice.
       ///</summary>
       //<returns></returns>
       public string Nombre { get; set; }

    }

    ///<summary>
    ///Clase que se encarga de calificar a las revistas segun el indice.
    ///</summary>
    ///<returns></returns>
    public class ImpactoIndice
    {

       ///<summary>
       ///Identificador del impacto.
       ///</summary>
       //<returns></returns>
       public int IdImpacto { get; set; }

       ///<summary>
       ///Grado de impacto que tiene la revista (Q1,Q2,Q3,Q4).
       ///</summary>
       //<returns></returns>
       public string QIndice { get; set; }

       ///<summary>
       ///Fecha en la que fue indexada la revista.
       ///</summary>
       //<returns></returns>
       public string Fecha { get; set; }

       ///<summary>
       ///Journalist impact factor.
       ///</summary>
       //<returns></returns>
       public string Jif { get; set; }

       ///<summary>
       ///Indice al que se le asocia el impacto.
       ///</summary>
       //<returns></returns>
       public int IdIndice { get; set; }

       ///<summary>
       ///Nombre de la revista. Se asume que es unico.
       //</summary>
       //<returns></returns>
       public string NomRevista { get; set; }


    }
}
