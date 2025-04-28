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
    public class UsuarioIntegrationTest : DbContextMocker
    {
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task UsuarioInsertar()
        {
            // Creación del cliente HTTP
            var cliente = factory.CreateClient();

            // Añadir ApiKey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            // Crear el mock del objeto Usuario
            var usuarioMock = UsuariosMocks.CrearMockUsuarios();

            // Serializar el objeto a JSON
            var contenido = new StringContent(JsonSerializer.Serialize(usuarioMock), Encoding.UTF8, "application/json");

            // Realizar la petición POST
            var response = await cliente.PostAsync("https://localhost:44337/api/Usuario/Insertar", contenido);
            response.EnsureSuccessStatusCode();

            // Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Verificar el contenido de la respuesta
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task UsuarioActualizar()
        {
            // Creación del cliente HTTP
            var cliente = factory.CreateClient();

            // Añadir ApiKey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            // Crear el mock del objeto Usuario actualizado
            var usuarioMock = UsuariosMocks.EditarMockUsuarios();

            // Serializar el objeto a JSON
            var contenido = new StringContent(JsonSerializer.Serialize(usuarioMock), Encoding.UTF8, "application/json");

            // Realizar la petición PUT
            var response = await cliente.PutAsync("https://localhost:44337/api/Usuario/Actualizar", contenido);
            response.EnsureSuccessStatusCode();

            // Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Verificar el contenido de la respuesta
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task UsuarioListar()
        {
            // Creación del cliente HTTP
            var cliente = factory.CreateClient();

            // Añadir ApiKey al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            // Realizar la petición GET para listar usuarios
            var response = await cliente.GetAsync("https://localhost:44337/api/Usuario/Listar");
            response.EnsureSuccessStatusCode();

            // Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Verificar el contenido de la respuesta
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }
    }
}