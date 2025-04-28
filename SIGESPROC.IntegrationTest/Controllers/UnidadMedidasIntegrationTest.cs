using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIGESPROC.IntegrationTest;
using SIGESPROC.IntegrationTest.Mocks;
using SIGESPROC.IntegrationTests;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Controllers
{
    [TestClass]
    public class UnidadMedidasIntegrationTest : DbContextMocker
    {

        //Apikey
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

       
        [TestMethod]
        public async Task UnidadMedidaInsertar()
        {

            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var UnidadMedidaMock = UnidadMedidasMocks.CrearMockUnidadMedidas();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(UnidadMedidaMock), System.Text.Encoding.UTF8, "application/json");

            //aqui hace la peticion a la url tipo Post
            var response = await cliente.PostAsync("https://localhost:44337/api/UnidadMedida/Insertar", contenido);
            response.EnsureSuccessStatusCode();

            //Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task UnidadMedidaEditar()
        {

            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var UnidadMedidaMock = UnidadMedidasMocks.EditarMockUnidadMedidas();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(UnidadMedidaMock), System.Text.Encoding.UTF8, "application/json");

            //aqui hace la peticion a la url tipo Post
            var response = await cliente.PutAsync("https://localhost:44337/api/UnidadMedida/Actualizar", contenido);
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