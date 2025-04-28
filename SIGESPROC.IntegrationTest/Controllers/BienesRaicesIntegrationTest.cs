using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIGESPROC.IntegrationTest;
using SIGESPROC.IntegrationTests;
using SIGESPROC.IntegrationTests.Mocks;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Controllers
{
    [TestClass]
    public class BienesRaicesIntegrationTest : DbContextMocker
    {

        //Apikey
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task BienRaizListar()
        {
            //creacion del cliente
            var cliente = factory.CreateClient();
            //añade el apikey a al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            // peticion a la url 
            var response = await cliente.GetAsync("https://localhost:44337/api/BienRaiz/Listar");
            response.EnsureSuccessStatusCode();

            //aserciones 
            Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task BienRaizInsertar()
        {

            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var bienRaizMock = BienesRaicesMocks.CrearMockBienRaiz();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(bienRaizMock), System.Text.Encoding.UTF8, "application/json");

            //aqui hace la peticion ala url tipo Post
            var response = await cliente.PostAsync("https://localhost:44337/api/BienRaiz/Insertar", contenido);
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