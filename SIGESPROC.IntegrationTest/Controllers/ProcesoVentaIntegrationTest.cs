using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIGESPROC.IntegrationTest.Mocks;
using SIGESPROC.IntegrationTests;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Controllers
{
    [TestClass]
    public class ProcesoVentaIntegrationTest : DbContextMocker
    {

        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task ProcesoVentaInsertar()
        {
            // Creamos el cliente
            var cliente = factory.CreateClient();

            // Añadimos la apikey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var procesoVentaMock = ProcesoVentaMocks.CrearMockProcesoVenta();


            // Serializa el objeto a JSON para enviarlo en el cuerpo de la petición
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(procesoVentaMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            // Realiza la petición a la URL tipo POST
            var response = await cliente.PostAsync("https://localhost:44337/api/ProcesoVenta/Insertar", contenido);

            // Comprueba si la respuesta no fue exitosa
            if (!response.IsSuccessStatusCode)
            {
                // Lee el contenido de la respuesta para obtener detalles del error
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorContent}");
                Assert.Fail($"Request failed with status code: {response.StatusCode} - {errorContent}");
            }

            // Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Lee el contenido de la respuesta 
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }


        [TestMethod]
        public async Task ProcesoVentaEditar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var procesoVentaMock = ProcesoVentaMocks.EditarMockProcesoVenta();

            // Serializa el objeto a JSON para enviarlo en el cuerpo de la petición
            var contenido = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(procesoVentaMock),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await cliente.PutAsync("https://localhost:44337/api/ProcesoVenta/Actualizar", contenido);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {errorContent}");
                Assert.Fail($"El error aca: {response.StatusCode} - {errorContent}");
            }

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }
    }
}

