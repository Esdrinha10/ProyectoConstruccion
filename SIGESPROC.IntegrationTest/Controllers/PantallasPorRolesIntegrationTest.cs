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
    public class PantallasPorRolesIntegrationTest : DbContextMocker
    {
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task PantallaPorRolInsertar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var pantallaPorRolMock = PantallaPorRolMocks.CrearMockPantallasPorRoles();
            var contenido = new StringContent(JsonSerializer.Serialize(pantallaPorRolMock), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("https://localhost:44337/api/PantallaPorRol/Insertar", contenido);
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task PantallaPorRolActualizar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var pantallaPorRolMock = PantallaPorRolMocks.EditarMockPantallasPorRoles();
            var contenido = new StringContent(JsonSerializer.Serialize(pantallaPorRolMock), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("https://localhost:44337/api/PantallaPorRol/Actualizar", contenido);
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task PantallaPorRolListar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var response = await cliente.GetAsync("https://localhost:44337/api/PantallaPorRol/Listar");
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }
    }
}