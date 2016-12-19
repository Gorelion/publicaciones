using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Publicaciones.Backend;
using System.Linq;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Publicaciones.Models;

namespace Publicaciones.Service {

    public class MainServiceTest : IDisposable
    {
        IMainService Service { get; set; }

        ILogger Logger { get; set; }

        public MainServiceTest()
        {
            // Logger Factory
            ILoggerFactory loggerFactory = new LoggerFactory().AddConsole().AddDebug();
            Logger = loggerFactory.CreateLogger<MainServiceTest>();

            Logger.LogInformation("Initializing Test ..");

            // SQLite en memoria
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            // Opciones de inicializacion del BackendContext
            var options = new DbContextOptionsBuilder<BackendContext>()
            .UseSqlite(connection)
            .Options;

            // inicializacion del BackendContext
            BackendContext backend = new BackendContext(options);
            // Crear la base de datos
            backend.Database.EnsureCreated();

            // Servicio a probar
            Service = new MainService(backend, loggerFactory);

            Logger.LogInformation("Initialize Test ok.");
        }

        [Fact]
        public void InitializeTest()
        {
            Logger.LogInformation("Testing IMainService.Initialize() ..");
            Service.Initialize();

            // No se puede inicializar 2 veces
            Assert.Throws<Exception>( () => { Service.Initialize(); });

            // Personas en la BD
            List<Persona> personas = Service.Personas();

            // Debe ser !=  de null
            Assert.True(personas != null);

            // Debe haber 4 personas
            Assert.True(personas.Count == 4);

            // Print de la persona
            foreach(Persona persona in personas) {
                Logger.LogInformation("Persona: {0}", persona.Nombre);
            }

            //Publicaciones en la base de datos
            List<Publicacion> publicaciones = Service.Publicaciones();

            // Debe ser !=  de null
            Assert.True(publicaciones != null);

            // Debe haber 3 publicaciones
            Assert.True(publicaciones.Count == 3);

            //print de las publicaciones
            foreach(Publicacion publicacion in publicaciones){
                Logger.LogInformation("Publicacion: {0}", publicacion.Titulo);
            }

            Logger.LogInformation("Test IMainService.Initialize() ok");
        }

        [Fact]
        public void publicacionesTest(){

            Logger.LogInformation("Testing IMainService.publicaciones(string rut) ..");
            Service.Initialize();

            //se obtiene la id de la primera ocurrencia (persona) de nombre Luis Felipe
            string rutLufe = Service.FindPersonas("Luis Felipe").First().Rut;

            //se obtiene la id de la primera ocurrencia (persona) de nombre Tomas
            string rutTomas = Service.FindPersonas("Tomas").First().Rut;

            //se obtiene la id de la primera ocurrencia (persona) de nombre Franco
            string rutFranco = Service.FindPersonas("Franco").First().Rut;

            //se obtiene la id de la primera ocurrencia (persona) de nombre Tomas
            string rutRodrigo = Service.FindPersonas("Rodrigo").First().Rut;

            //se obtiene la id de la primera ocurrencia (publicacion) de titulo publicacion1
            int idPublicacion1 = Service.FindPublicaciones("publicacion1").First().IdPublicacion;

            //se obtiene la id de la primera ocurrencia (publicacion) de titulo publicacion2
            int idPublicacion2 = Service.FindPublicaciones("publicacion2").First().IdPublicacion;

            //se obtiene la id de la primera ocurrencia (publicacion) de titulo publicacion3
            int idPublicacion3 = Service.FindPublicaciones("publicacion3").First().IdPublicacion;

            //lufe es autor de la publicacion 3
            Autor autoria1 = new Autor();
            autoria1.IdPersona = rutLufe.ToString();
            autoria1.IdPublicacion = idPublicacion3;
            Service.Add(autoria1);

            //lufe es autor de la publicacion 2
            Autor autoria2 = new Autor();
            autoria2.IdPersona = rutLufe.ToString();
            autoria2.IdPublicacion = idPublicacion2;
            Service.Add(autoria2);

            //tomas es autor de la publicacion 1
            Autor autoria3 = new Autor();
            autoria3.IdPersona = rutTomas.ToString();
            autoria3.IdPublicacion = idPublicacion1;
            Service.Add(autoria3);

            //tomas es autor de la publicacion 2
            Autor autoria4 = new Autor();
            autoria4.IdPersona = rutTomas.ToString();
            autoria4.IdPublicacion = idPublicacion2;
            Service.Add(autoria4);

            //tomas es autor de la publicacion 3
            Autor autoria5 = new Autor();
            autoria5.IdPersona = rutTomas.ToString();
            autoria5.IdPublicacion = idPublicacion3;
            Service.Add(autoria5);

            //Franco es autor de la publicacion 3
            Autor autoria6 = new Autor();
            autoria6.IdPersona = rutFranco.ToString();
            autoria6.IdPublicacion = idPublicacion3;
            Service.Add(autoria6);

            //se obtienen las publicaciones en las que Lufe figura como autor
            List<Publicacion> publicacionesLufe = Service.Publicaciones(rutLufe);

            // publicacionesLufe debe ser != null
            Assert.True(publicacionesLufe != null);
            //lufe solo ha sido autor de 2 publicaciones
            Assert.True(publicacionesLufe.Count == 2);

            //print de las publicaciones de Lufe
            foreach(Publicacion publicacion in publicacionesLufe){
                Logger.LogInformation("Publicacion de Lufe: {0}", publicacion.Titulo);
            }

            //se obtienen las publicaciones en las que Tomas figura como autor
            List<Publicacion> publicacionesTomas = Service.Publicaciones(rutTomas);

            // publicacionesTomas debe ser != null
            Assert.True(publicacionesTomas != null);
            //tomas solo ha sido autor de 3 publicaciones
            Assert.True(publicacionesTomas.Count == 3);

            //print de las publicaciones de tomas
            foreach(Publicacion publicacion in publicacionesTomas){
                Logger.LogInformation("Publicacion de Tomas: {0}", publicacion.Titulo);
            }

            //se obtienen las publicaciones en las que Franco figura como autor
            List<Publicacion> publicacionesFranco = Service.Publicaciones(rutFranco);

            // publicacionesFranco debe ser != null
            Assert.True(publicacionesFranco != null);
            //Franco solo ha sido autor de 1 publicacion
            Assert.True(publicacionesFranco.Count == 1);

            //print de las publicaciones de Franco
            foreach(Publicacion publicacion in publicacionesFranco){
                Logger.LogInformation("Publicacion de Franco: {0}", publicacion.Titulo);
            }

            //se obtienen las publicaciones en las que Rodrigo figura como autor
            List<Publicacion> publicacionesRodrigo = Service.Publicaciones(rutRodrigo);

            // publicacionesRodrigo debe ser != null
            Assert.True(publicacionesRodrigo != null);
            // Rodrigo no deberia tener publicaciones
            Assert.True(publicacionesRodrigo.Count == 0);

            //print de las publicaciones de Rodrigo, no deberia imprimir nada
            foreach(Publicacion publicacion in publicacionesRodrigo){
                Logger.LogInformation("Publicacion de Rodrigo: {0}", publicacion.Titulo);
            }

            Logger.LogInformation("Test IMainService.publicaciones(string rut) ok");            
        }

        [Fact]
        public void revistasTest(){

            Service.Initialize();

            //Se obtiene la id de la primera ocurrencia (persona) de nombre Luis Felipe
            string rutLufe = Service.FindPersonas("Luis Felipe").First().Rut;

            //Se obtiene la id de la primera ocurrencia (persona) de nombre Tomas
            string rutTomas = Service.FindPersonas("Tomas").First().Rut;

            //Se obtiene la id de la primera ocurrencia (persona) de nombre Franco
            string rutFranco = Service.FindPersonas("Franco").First().Rut;

            //se obtiene la id de la primera ocurrencia (publicacion) de titulo publicacion1
            int idPublicacion1 = Service.FindPublicaciones("publicacion1").First().IdPublicacion;

            //se obtiene la id de la primera ocurrencia (publicacion) de titulo publicacion2
            int idPublicacion2 = Service.FindPublicaciones("publicacion2").First().IdPublicacion;

            //se obtiene la id de la primera ocurrencia (publicacion) de titulo publicacion3
            int idPublicacion3 = Service.FindPublicaciones("publicacion3").First().IdPublicacion;

            //lufe es autor de la publicacion 3
            Autor autoria1 = new Autor();
            autoria1.IdPersona = rutLufe.ToString();
            autoria1.IdPublicacion = idPublicacion3;
            Service.Add(autoria1);

            //lufe es autor de la publicacion 2
            Autor autoria2 = new Autor();
            autoria2.IdPersona = rutLufe.ToString();
            autoria2.IdPublicacion = idPublicacion2;
            Service.Add(autoria2);

            //tomas es autor de la publicacion 1
            Autor autoria3 = new Autor();
            autoria3.IdPersona = rutTomas.ToString();
            autoria3.IdPublicacion = idPublicacion1;
            Service.Add(autoria3);

            //tomas es autor de la publicacion 2
            Autor autoria4 = new Autor();
            autoria4.IdPersona = rutTomas.ToString();
            autoria4.IdPublicacion = idPublicacion2;
            Service.Add(autoria4);

            //tomas es autor de la publicacion 3
            Autor autoria5 = new Autor();
            autoria5.IdPersona = rutTomas.ToString();
            autoria5.IdPublicacion = idPublicacion3;
            Service.Add(autoria5);

            //Franco es autor de la publicacion 3
            Autor autoria6 = new Autor();
            autoria6.IdPersona = rutFranco.ToString();
            autoria6.IdPublicacion = idPublicacion3;
            Service.Add(autoria6);

            //Se obtienen las publicaciones en las que Lufe figura como autor
            List<Publicacion> publicacionesLufe = Service.Publicaciones(rutLufe);

            //Se obtienen las publicaciones en las que Tomas figura como autor
            List<Publicacion> publicacionesTomas = Service.Publicaciones(rutTomas);

            //Se obtienen las publicaciones en las que Franco figura como autor
            List<Publicacion> publicacionesFranco = Service.Publicaciones(rutFranco);

            //Probando que las publicaciones de Lufe estén en las revistas correctas.
            List<string> nombresEsperadosRevistasLufe = new List<string>();
            nombresEsperadosRevistasLufe.Add("Conozca Mas");
            nombresEsperadosRevistasLufe.Add("Science");

            List<String> nombresRealesRevistasLufe = new List<string>();

            foreach(Publicacion publicacion in publicacionesLufe){

                Revista revista = Service.FindRevistaCodigo(publicacion.IdRevista);
                nombresRealesRevistasLufe.Add(revista.Nombre);

            }

            nombresEsperadosRevistasLufe.Sort();
            nombresRealesRevistasLufe.Sort();
            Assert.Equal(nombresEsperadosRevistasLufe,nombresRealesRevistasLufe);

            //Probando que las publicaciones de Tomas estén en las revistas correctas.
            List<string> nombresEsperadosRevistasTomas = new List<string>();
            nombresEsperadosRevistasTomas.Add("Conozca Mas");
            nombresEsperadosRevistasTomas.Add("Science");
            nombresEsperadosRevistasTomas.Add("Muy Interesante");

            List<String> nombresRealesRevistasTomas = new List<string>();

            foreach(Publicacion publicacion in publicacionesTomas){

                Revista revista = Service.FindRevistaCodigo(publicacion.IdRevista);
                nombresRealesRevistasTomas.Add(revista.Nombre);

            }

            nombresEsperadosRevistasTomas.Sort();
            nombresRealesRevistasTomas.Sort();
            Assert.Equal(nombresEsperadosRevistasTomas,nombresRealesRevistasTomas);

            //Probando que las publicaciones de Franco estén en las revistas correctas.
            List<string> nombresEsperadosRevistasFranco = new List<string>();
            nombresEsperadosRevistasFranco.Add("Science");

            List<String> nombresRealesRevistasFranco = new List<string>();

            foreach(Publicacion publicacion in publicacionesFranco){

                Revista revista = Service.FindRevistaCodigo(publicacion.IdRevista);
                nombresRealesRevistasFranco.Add(revista.Nombre);

            }

            nombresEsperadosRevistasFranco.Sort();
            nombresRealesRevistasFranco.Sort();
            Assert.Equal(nombresEsperadosRevistasFranco,nombresRealesRevistasFranco);

            Logger.LogInformation("Test passed");
        
        }

        void IDisposable.Dispose()
        {
            // Aca eliminar el Service
        }
    }

}