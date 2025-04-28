using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIGESPROC.IntegrationTest.Mocks;
using SIGESPROC.IntegrationTests;
using SIGESPROC.IntegrationTests.Mocks;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Controllers
{
    [TestClass]
    public class PantallasIntegrationTest : DbContextMocker
    {
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task PantallaInsertar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var pantallaMock = PantallasMocks.CrearMockPantallas();
            var contenido = new StringContent(JsonSerializer.Serialize(pantallaMock), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("https://localhost:44337/api/Pantalla/Insertar", contenido);
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task PantallaActualizar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var pantallaMock = PantallasMocks.EditarMockPantallas();
            var contenido = new StringContent(JsonSerializer.Serialize(pantallaMock), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("https://localhost:44337/api/Pantalla/Actualizar", contenido);
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task PantallaListar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var response = await cliente.GetAsync("https://localhost:44337/api/Pantalla/Listar");
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }
    }
}