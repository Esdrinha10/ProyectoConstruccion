using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIGESPROC.IntegrationTest;
using SIGESPROC.IntegrationTest.Mocks;
using SIGESPROC.IntegrationTests;
using SIGESPROC.IntegrationTests.Mocks;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Controllers
{
    [TestClass]
    public class TerrenosIntegrationTest : DbContextMocker
    {

        //Apikey
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";


        [TestMethod]
        public async Task TerrenosInsertar()
        {
            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var terrenoMock = TerrenosMocks.CrearMockTerrenos();

            // Serializa el objeto a JSON para enviarlo en el cuerpo de la peticion
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(terrenoMock), System.Text.Encoding.UTF8, "application/json");

            // Aquí hace la petición a la URL tipo Post
            var response = await cliente.PostAsync("https://localhost:44337/api/Terreno/Insertar", contenido);

            // Verifica si la respuesta fue exitosa
            if (!response.IsSuccessStatusCode)
            {
                // Lee el contenido del error para depurar
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorContent}");
            }

            // Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "La respuesta no fue exitosa");
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }


        [TestMethod]
        public async Task TerrenosEditar()
        {
            //creamos el cliente
            var cliente = factory.CreateClient();

            //añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var terrenoMock = TerrenosMocks.EditarMockTerrenos();

            // Serializa el objeto a JSON para enviarlo en el cuerpo de la petición
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(terrenoMock), System.Text.Encoding.UTF8, "application/json");

            // Aquí hace la petición a la URL tipo Put (en lugar de Post)
            var response = await cliente.PutAsync("https://localhost:44337/api/Terreno/Actualizar", contenido);

            // Verifica si la respuesta fue exitosa
            if (!response.IsSuccessStatusCode)
            {
                // Lee el contenido del error para depurar
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorContent}");
            }

            // Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "La respuesta no fue exitosa");
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }


        [TestMethod]
        public async Task TerrenosListar()
        {
            //creacion del cliente
            var cliente = factory.CreateClient();
            //añade el apikey a al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            // peticion a la url 
            var response = await cliente.GetAsync("https://localhost:44337/api/Terreno/Listar");
            response.EnsureSuccessStatusCode();

            //aserciones 
            Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
            Assert.IsNotNull(response);
        }
    }
}
