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
    public class FletesIntegrationTest : DbContextMocker
    {
        //Apikey
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";


        [TestMethod]
        public async Task FletesListar()
        {
            //creacion del cliente
            var cliente = factory.CreateClient();
            //añade el apikey a al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            // peticion a la url 
            var response = await cliente.GetAsync("https://localhost:44337/api/FleteEncabezado/Listar");
            response.EnsureSuccessStatusCode();

            //aserciones 
            Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task FletesInsertar()
        {

            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var FletesMock = FletesMocks.CrearMockFletes();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(FletesMock), System.Text.Encoding.UTF8, "application/json");

            //aqui hace la peticion ala url tipo Post
            var response = await cliente.PostAsync("https://localhost:44337/api/FleteEncabezado/Insertar", contenido);
            response.EnsureSuccessStatusCode();

            //Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }
        [TestMethod]
        public async Task FletesActualizar()
        {

            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var FletesMock = FletesMocks.EditarMockFletes();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(FletesMock), System.Text.Encoding.UTF8, "application/json");

            //aqui hace la peticion ala url tipo Post
            var response = await cliente.PutAsync("https://localhost:44337/api/FleteEncabezado/Actualizar", contenido);
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
