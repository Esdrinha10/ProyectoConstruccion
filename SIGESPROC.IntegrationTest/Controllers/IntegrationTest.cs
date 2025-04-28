using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIGESPROC.API;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SIGESPROC.DataAccess.Context;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SIGESPROC.Entities.Entities;
using System;

namespace SIGESPROC.IntegrationTests
{
    public class DbContextMocker : IDisposable
    {
        internal WebApplicationFactory<Program> factory;
        public SIGESPROCContext dbContext;

        public DbContextMocker()
        {
            // Configura la fabrica de la aplicacion para pruebas de integración
            factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Elimina cualquier instancia existente del contexto de base de datos para poder usar InMemory
                    services.RemoveAll(typeof(DbContextOptions<SIGESPROCContext>));
                    services.AddDbContext<SIGESPROCContext>(op =>
                    {
                        op.UseInMemoryDatabase("SIGESPROC")
                          .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                    });
                });
            });

            // Crea el servicio de contexto
            var scope = factory.Services.CreateScope();
            var scopeService = scope.ServiceProvider;
            dbContext = scopeService.GetRequiredService<SIGESPROCContext>();
            dbContext.Database.EnsureCreated();
            dbContext.SaveChanges();
        }

        // metodo para limpiar el contexto y eliminar la base de datos en memoria
        public void Dispose()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}