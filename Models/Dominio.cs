using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Publicaciones.Models
{   
    ///<summary>
    /// Clase que implementa Persona
    ///</summary>
    ///<remarks>esta clase se encarga de hacer una representacion de una Persona dentro del sistema</remarks>
    public class Persona
    {
        [Key]
        /// <summary>
        /// Rut de la persona.
        /// </summary>
        public string Rut { get; set; }

        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido de la persona.
        /// </summary>
        public string Apellido { get; set; }
        
    }
    ///<summary>
    /// Clase implementa Publicacion
    ///</summary>
    ///<remarks>clase que hace una representacion de una publicacion dentro del sistema</remarks>
    public class Publicacion
    {
        [Key]
        /// <summary>
        /// Identificador de la publicacion.
        /// </summary>
        public int IdPublicacion { get; set; }

        /// <summary>
        /// Titulo de la publicacion.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Fecha de inicio de la publicacion, desde que se comenzo a escribir.
        /// </summary>
        public string FechaInicio { get; set; }

        /// <summary>
        /// Fecha de termino de la publicacion, momento en el que fue publicada e indizada 
        /// </summary>
        public string FechaTermino { get; set; }

        /// <summary>
        /// Abstract (resumen) de la publicacion.
        /// </summary>
        public string Abstract { get; set; }

        /// <summary>
        /// Linea investigativa de la publicacion.
        /// </summary>
        public string LineaInvestigativa { get; set; }

        /// <summary>
        /// Area de desarrollo de la investigacion.
        /// </summary>
        public string AreaDesarrollo { get; set; }

        /// <summary>
        /// Identificador de la revista asociada.
        /// </summary>
        // <returns></returns>
        public string IdRevista {get; set; }
        public string NombreRevista {get; set; }
        
    }
    ///<summary>
    /// Clase implementa Autor 
    ///</summary>
    ///<remarks>clase que se encarga de hacer una representacionde un Autor dentro del sistema (Se genera cuando Persona hace una Publicacion)</remarks>
    public class Autor
    {
        
        /// <summary>
        /// Fecha en que hizo la publicacion.
        /// </summary>
        public string Fecha { get; set; }
        
        /// <summary>
        /// Identificador unico de la publicacion.
        /// </summary>
        public int IdPublicacion { get; set; }

        /// <summary>
        /// Identificador de la persona responsable de la publicacion.
        /// </summary>
        public string IdPersona { get; set; }

    }
    
    ///<summary>
    /// Clase implementa revista
    ///</summary>
    ///<remarks>clase que hace una representacion de una revista dentro del sistema donde se ingresan las publicaciones</remarks>
     public class Revista
     {
        
         [Key]
         /// <summary>
         /// Id de la revista
         /// </summary>
         public string Id { get; set; }

         /// <summary>
         /// Nombre de la revista
         /// </summary>
         public string Nombre { get; set; }
         
         /// <summary>
         /// International Standard Serial Number
         /// </summary>
         public string ISSN { get; set; }  
     }

    ///<summary>
    /// Clase implementa revistas.
    ///</summary>
    ///<remarks>clase que se encarga de hacer una representacionde un indice para cada revista</remarks>
    public class Indice
    {

       [Key]
       ///<summary>
       ///Identificador del indice.
       ///</summary>
       public int IdIndice { get; set; }

       ///<summary>
       ///Nombre del indice.
       ///</summary>
       public string Nombre { get; set; }

    }

    ///<summary>
    ///Clase que implementa una clasificacion con un ImpactoIndice
    ///</summary>
    ///<remarks>clase que se encarga de dar una clasificacion a cada indice a traves de un impacto de manera numerica</remarks>
    public class ImpactoIndice
    {

       [Key]
       ///<summary>
       ///Identificador del impacto.
       ///</summary>
       public int IdImpacto { get; set; }

       ///<summary>
       ///Grado de impacto que tiene la revista (Q1,Q2,Q3,Q4).
       ///</summary>
       public string QIndice { get; set; }

       ///<summary>
       ///Fecha en la que fue indexada la revista.
       ///</summary>
       public string Fecha { get; set; }

       ///<summary>
       ///Journalist impact factor.
       ///</summary>
       public string Jif { get; set; }

       ///<summary>
       ///Indice al que se le asocia el impacto.
       ///</summary>
       public int IdIndice { get; set; }

       ///<summary>
       ///Nombre de la revista. Se asume que es unico.
       ///</summary>
       public string NomRevista { get; set; }


    }
}
