using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Publicaciones.Backend;
using Publicaciones.Models;

namespace Publicaciones.Service
{

    /// <summary>
    /// Metodos de la interface
    /// </summary>
    public interface IMainService {
        void Add(Persona persona); 

        void Add(Publicacion publicacion);

        void Add(Autor autor);

        List < Persona > FindPersonas(string nombre);

        List <Publicacion> FindPublicaciones(string titulo); 

        List <Publicacion> Publicaciones(string rut);

        List <Persona> Personas();

        List <Publicacion> Publicaciones();

        List <Autor> Autores();

        void Initialize(); 
    }

    /// <summary>
    /// Implementacion de la interface IMainService
    /// </summary>
    public class MainService:IMainService {

        /// <summary>
        /// Acceso al Backend
        /// </summary>
        /// <returns></returns>
        private BackendContext BackendContext { get; set; }

        /// <summary>
        /// The Logger 
        /// </summary>
        /// <returns></returns>
        private ILogger Logger { get; set; }

        private Boolean Initialized { get; set; }

        /// <summary>
        /// Constructor via DI
        /// </summary>
        /// <param name="backendContext"></param>
        /// <param name="loggerFactory"></param>
        public MainService(BackendContext backendContext, ILoggerFactory loggerFactory) {

            // Inicializacion del Logger
            Logger = loggerFactory?.CreateLogger < MainService > (); 
            if (Logger == null) {
                throw new ArgumentNullException(nameof(loggerFactory)); 
            }

            // Obtengo el backend
            BackendContext = backendContext; 
            if (BackendContext == null) {
                throw new ArgumentNullException("MainService requiere del BackendService != null"); 
            }

            // No se ha inicializado
            Initialized = false;

            Logger.LogInformation("MainService created"); 
        }

        public void Add(Persona persona) {

            // Guardo la Persona en el Backend
            BackendContext.Personas.Add(persona); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }

        public void Add(Publicacion publicacion) {

            // Guardo la publicacion en el Backend
            BackendContext.Publicaciones.Add(publicacion); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }

        public void Add(Autor autor) {

            // Guardo el autor en el Backend
            BackendContext.Autores.Add(autor); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }

        public List < Persona > FindPersonas(string nombre) {
            return BackendContext.Personas
                .Where(p => p.Nombre.Contains(nombre))
                .OrderBy(p => p.Nombre)
                .ToList(); 
        }

        public List < Publicacion > FindPublicaciones(string titulo) {
            return BackendContext.Publicaciones
                .Where(p => p.Titulo.Contains(titulo))
                .OrderBy(p => p.Titulo)
                .ToList(); 
        }

        public List<Persona> Personas() {
            return BackendContext.Personas.ToList();
        }

        public List<Publicacion> Publicaciones() {
            return BackendContext.Publicaciones.ToList();
        }

        public List<Autor> Autores() {
            return BackendContext.Autores.ToList();
        }

        public void Initialize() {

            if (Initialized) {
                throw new Exception("Solo se permite llamar este metodo una vez");
            }

            Logger.LogDebug("Realizando Inicializacion .."); 
            // Personas por defecto
            Persona persona1 = new Persona(); 
            persona1.Nombre = "Luis Felipe"; 
            persona1.Apellido = "Gutierrez"; 

            // Agrego las personas al backend
            this.Add(persona1);

            Persona persona2 = new Persona(); 
            persona2.Nombre = "Tomas"; 
            persona2.Apellido = "Alegre";

            this.Add(persona2);

            Persona persona3 = new Persona(); 
            persona3.Nombre = "Franco"; 
            persona3.Apellido = "Aramayo";

            this.Add(persona3);

            Persona persona4 = new Persona(); 
            persona4.Nombre = "Rodrigo"; 
            persona4.Apellido = "Pizarro";

            this.Add(persona4);

            //Se agregan las publicaciones por defecto
            Publicacion publicacion1 = new Publicacion();
            publicacion1.Titulo = "publicacion1";
            this.Add(publicacion1);

            Publicacion publicacion2 = new Publicacion();
            publicacion2.Titulo = "publicacion2";
            this.Add(publicacion2); 

            Publicacion publicacion3 = new Publicacion();
            publicacion3.Titulo = "publicacion3";
            this.Add(publicacion3);

            foreach (Persona p in BackendContext.Personas) {
                Logger.LogDebug("Persona: {0}", p); 
            }

            Initialized = true;

            Logger.LogDebug("Inicializacion terminada :)");
        }

        ///<summary>
        ///Metodo que obtiene las publicaciones de una persona segun el rut.
        ///</summary>
        /// <param name="rut"> Rut de la persona autora</param>
        /// <returns>Lista con todas las publicaciones que hizo la persona con rut</returns>
        public List <Publicacion> Publicaciones(string rut){   
            //Lista vacía con las publicaciones a retornar         
            List<Publicacion> publicaciones = new List<Publicacion>();

            //Se recorren todas las autorias que existen en la base de datos
            List<Autor> autorias = BackendContext.Autores.Where(s => s.IdPersona.Equals(rut)).ToList();

            //Por cada autoría encontrada, 
            foreach (Autor autor in autorias){
                //Se obtiene la publicacion involucrada en la autoria actual
                Publicacion publicacion = BackendContext.Publicaciones.Where(s => s.IdPublicacion.Equals(autor.IdPublicacion)).SingleOrDefault();
                //Se agrega la publicacion encontrada a la lista que se retorna
                publicaciones.Add(publicacion);
            }
            return publicaciones;
        }

    }

}