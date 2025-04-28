using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIGESPROC.IntegrationTest.Mocks;
using SIGESPROC.IntegrationTests;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SIGESPROC.IntegrationTest.Controllers
{
    [TestClass]
    public class RolIntegrationTest : DbContextMocker
    {
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task RolInsertar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            // Usamos el nuevo mock que incluye las pantallas seleccionadas
            var rolMock = RolesMocks.CrearMockRolViewModel();
            var contenido = new StringContent(JsonSerializer.Serialize(rolMock), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("https://localhost:44337/api/Rol/Insertar", contenido);
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task RolActualizar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            // Usamos el mock de actualización
            var rolMock = RolesMocks.EditarMocKRoles();
            var contenido = new StringContent(JsonSerializer.Serialize(rolMock), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("https://localhost:44337/api/Rol/Actualizar", contenido);
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task RolListar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var response = await cliente.GetAsync("https://localhost:44337/api/Rol/Listar");
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }
    }
}