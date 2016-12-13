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

            

        }

        void IDisposable.Dispose()
        {
            // Aca eliminar el Service
        }
    }

}