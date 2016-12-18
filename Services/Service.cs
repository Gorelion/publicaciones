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

        void Add(Revista revista);

        void Add(Indice indice);

        void Add(ImpactoIndice impactoIndice);

        List < Persona > FindPersonas(string nombre);

        List <Publicacion> FindPublicaciones(string titulo); 

        List <Publicacion> Publicaciones(string rut);

        List <Persona> Personas();

        List <Publicacion> Publicaciones();

        List <Autor> Autores();

        List <Revista> Revistas();

        List <Indice> Indices();

        List <ImpactoIndice> ImpactoIndices();

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

        /// <summary>
        /// Metodo que agrega una persona a la BD
        /// </summary>
        /// <param name="persona">persona a agregar</param>
        public void Add(Persona persona) {

            // Guardo la Persona en el Backend
            BackendContext.Personas.Add(persona); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }

        /// <summary>
        /// Metodo que agrega una publicacion a la BD
        /// </summary>
        /// <param name="publicacion">publicacion a agregar</param>
        public void Add(Publicacion publicacion) {

            // Guardo la publicacion en el Backend
            BackendContext.Publicaciones.Add(publicacion); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }

        /// <summary>
        /// Metodo que agrega un autor
        /// </summary>
        /// <param name="autor">autor a agregar</param>
        public void Add(Autor autor) {

            // Guardo el autor en el Backend
            BackendContext.Autores.Add(autor); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }

        /// <summary>
        /// Metodo que agrega una revista
        /// </summary>
        /// <param name="revista">revista a agregar</param>
        public void Add(Revista revista) {

           //Guardo la revista en el Backend.
           BackendContext.Revistas.Add(revista);

           //Guardo los cambios.
           BackendContext.SaveChanges();

        }

        /// <summary>
        /// Metodo que agrega un indice.
        /// </summary>
        /// <param name="indice">Indice a agregar</param>
        public void Add(Indice indice) {

            // Guardo el autor en el Backend
            BackendContext.Indices.Add(indice); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }

        /// <summary>
        /// Metodo que agrega un indice de impacto.
        /// </summary>
        /// <param name="impactoIndice">Indice de impacto a agregar</param>
        public void Add(ImpactoIndice impactoIndice) {

            // Guardo el autor en el Backend
            BackendContext.ImpactoIndices.Add(impactoIndice); 

            // Guardo los cambios
            BackendContext.SaveChanges(); 
        }

        ///<summary>
        /// Metodo que se encarga de buscar personas por el Nombre
        ///</summary>
        ///<param name="nombre">nombre de la persona a la cual se buscara</param>
        ///<return>retorna una lista con las personas que coicidan el nombre</return>
        public List < Persona > FindPersonas(string nombre) {
            return BackendContext.Personas
                .Where(p => p.Nombre.Contains(nombre))
                .OrderBy(p => p.Nombre)
                .ToList(); 
        }
        ///<summary>
        /// Metodo que se encarga de obtener las publicaciones segun su titulo
        ///</summary>
        ///<param name="titulo">titulo de la publicacion que se quiere buscar</param>
        ///<returns>Lista con las publicaciones con el nombre ingresado</returns>
        public List < Publicacion > FindPublicaciones(string titulo) {
            return BackendContext.Publicaciones
                .Where(p => p.Titulo.Contains(titulo))
                .OrderBy(p => p.Titulo)
                .ToList(); 
        }

        /// <summary>
        /// Metodo que retorna una lista con todas las personas en la base de datos, sin un orden especifico.
        /// </summary>
        /// <returns>Retorna la lista de personas en la base de datos.</returns>
        public List<Persona> Personas() {
            return BackendContext.Personas.ToList();
        }

        /// <summary>
        /// Metodo que retorna una lista con todas las publicaciones en la base de datos, sin un orden especifico.
        /// </summary>
        /// <returns>Retorna la lista de publicaciones en la base de datos.</returns>
        public List<Publicacion> Publicaciones() {
            return BackendContext.Publicaciones.ToList();
        }

        /// <summary>
        /// Metodo que retorna una lista con todos los autores en la base de datos, sin un orden especifico.
        /// </summary>
        /// <returns>Retorna la lista de autores en la base de datos.</returns>
        public List<Autor> Autores() {
            return BackendContext.Autores.ToList();
        }

        /// <summary>
        /// Metodo que retorna una lista con todas las revistas en la base de datos, sin un orden especifico.
        /// </summary>
        /// <returns>Retorna la lista de autores en la base de datos.</returns>
        public List<Revista> Revistas() {
            return BackendContext.Revistas.ToList();
        }

        /// <summary>
        /// Metodo que retorna una lista con todos los indices en la base de datos, sin un orden especifico.
        /// </summary>
        /// <returns>Retorna la lista de indices en la base de datos.</returns>
        public List<Indice> Indices() {
            return BackendContext.Indices.ToList();
        }

        /// <summary>
        /// Metodo que retorna una lista con todos los indices de impacto en la base de datos, sin un orden especifico.
        /// </summary>
        /// <returns>Retorna la lista de indices de impacto en la base de datos.</returns>
        public List<ImpactoIndice> ImpactoIndices() {
            return BackendContext.ImpactoIndices.ToList();
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

            Revista revista1 = new Revista();
            revista1.Nombre = "Muy Interesante";
            this.Add(revista1);

            Revista revista2 = new Revista();
            revista2.Nombre = "Conozca Mas";
            this.Add(revista2);

            Revista revista3 = new Revista();
            revista3.Nombre = "Science";
            this.Add(revista3);

            publicacion1.NombreRevista = revista1.Nombre;
            publicacion2.NombreRevista = revista2.Nombre;
            publicacion3.NombreRevista = revista3.Nombre;

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
