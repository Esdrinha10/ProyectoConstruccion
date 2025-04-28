using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIGESPROC.IntegrationTest.Mocks;
using SIGESPROC.IntegrationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Controllers
{
    [TestClass]
    public class AgenteBienRaizIntegrationTest : DbContextMocker
    {      //Apikey
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task AgenteBienRaizInsertar()
        {

            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var bienRaizMock = AgenteBienRaizMocks.CrearMockAgenteBienRaiz();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(bienRaizMock), System.Text.Encoding.UTF8, "application/json");

            //aqui hace la peticion ala url tipo Post
            var response = await cliente.PostAsync("https://localhost:44337/api/AgenteBienesRaices/Insertar", contenido);
            response.EnsureSuccessStatusCode();

            //Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task AgenteBienRaizActualizar()
        {

            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var bienRaizMock = AgenteBienRaizMocks.CrearMockAgenteBienRaiz();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(bienRaizMock), System.Text.Encoding.UTF8, "application/json");

            //aqui hace la peticion ala url tipo Post
            var response = await cliente.PutAsync("https://localhost:44337/api/AgenteBienesRaices/Actualizar", contenido);
            response.EnsureSuccessStatusCode();

            //Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

    }
}
