using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIGESPROC.IntegrationTest.Mocks;
using SIGESPROC.IntegrationTests;
using SIGESPROC.IntegrationTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Controllers
{
    [TestClass]
    public class DiagramaGanttIntegrationTest : DbContextMocker
    {
        //Declaramos en una variable la api Key
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task EtapasPorProyectoListar()
        {
            //creacion del cliente
            var cliente = factory.CreateClient();
            //apikey 
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);
            // peticion 
            var response = await cliente.GetAsync("https://localhost:44337/api/EtapaPorProyecto/Listar/32");
            response.EnsureSuccessStatusCode();
            //aserciones 
            Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task ActividadPorEtapaListar()
        {
            //creacion del cliente
            var cliente = factory.CreateClient();
            //apikey
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);
            // peticion
            var response = await cliente.GetAsync("https://localhost:44337/api/ActividadPorEtapa/Listar/1");
            response.EnsureSuccessStatusCode();

            //aserciones 
            Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
            Assert.IsNotNull(response);
        }


    }
}
