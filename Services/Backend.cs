using Microsoft.EntityFrameworkCore; 
using Publicaciones.Models;

namespace Publicaciones.Backend {

    /// <summary>
    /// Representacion de la base de datos.
    /// </summary>
    public class BackendContext : DbContext {

        /// <summary>
        /// Constructor vacio para pruebas
        /// </summary>
        public BackendContext() {
            
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        public BackendContext(DbContextOptions < BackendContext > options) : base(options) {
        }

        /// <summary>
        /// Representacion de las Personas del Backend
        /// </summary>
        /// <returns>Link a la BD de Personas</returns>
        public DbSet < Persona > Personas {get; set; }

        /// <summary>
        /// Representacion de la Publicacion del Backend
        /// </summary>
        /// <returns>Link a la BD de Publicacion</returns>
        public DbSet < Publicacion > Publicaciones {get; set; }

        /// <summary>
        /// Representacion de los Autores del Backend
        /// </summary>
        /// <returns>Link a la BD de Autor</returns>
        public DbSet < Autor > Autores {get; set; }

        /// <summary>
        /// Representacion de los Indices del Backend
        /// </summary>
        /// <returns>Link a la BD de Indice</returns>
        public DbSet < Indice > Indices {get; set; }

        /// <summary>
        /// Representacion de los Indices de Impacto del Backend
        /// </summary>
        /// <returns>Link a la BD de Indice de Impacto</returns>
        public DbSet < ImpactoIndice > ImpactoIndices {get; set; }

        /// <summary>
        /// Representacion de las Revistas del Backend
        /// </summary>
        /// <returns>Link a la BD de Indice</returns>
        public DbSet < Revista > Revistas {get; set; }

        ///<summary>
        ///Establecimiento de la clave primaria compuesta de Autor
        ///</summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Autor>().HasKey(s => new { s.IdPersona, s.IdPublicacion});
            base.OnModelCreating(modelBuilder);

        }

    }

}