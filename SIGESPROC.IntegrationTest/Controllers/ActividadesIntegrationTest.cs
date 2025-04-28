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
{   [TestClass]
    public  class ActividadesIntegrationTest : DbContextMocker
    {
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task ActividadesCrearTest()
        {

            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var ActividadMock = ActividadesMocks.CrearMockActividad();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(ActividadMock), System.Text.Encoding.UTF8, "application/json");

            //aqui hace la peticion a la url tipo Post
            var response = await cliente.PostAsync("https://localhost:44337/api/Actividade/Insertar", contenido);
            //response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorContent}");
                Assert.Fail($"Request failed with status code: {response.StatusCode} - {errorContent}");
            }

            //Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }


        [TestMethod]
        public async Task ActividadEditarTest()
        {

            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var ActividadMock = ActividadesMocks.EditarMockActividad();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(ActividadMock), System.Text.Encoding.UTF8, "application/json");
            Console.WriteLine(contenido);

            //aqui hace la peticion ala url tipo Post
            var response = await cliente.PutAsync("https://localhost:44337/api/Actividade/Actualizar", contenido);
            //response.EnsureSuccessStatusCode();

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
