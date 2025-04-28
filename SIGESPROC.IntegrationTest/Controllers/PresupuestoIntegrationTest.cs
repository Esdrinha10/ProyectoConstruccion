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
    public class PresupuestoIntegrationTest : DbContextMocker
    {
        //Apikey
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task PresupuestoListar()
        {
            var cliente = factory.CreateClient();
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var response = await cliente.GetAsync("https://localhost:44337/api/PresupuestoEncabezado/Listar");
            response.EnsureSuccessStatusCode();

            Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task PresupuestoInsertar()
        {
            var cliente = factory.CreateClient();

            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var mock = PresupuestoMock.PresupuestoEncabezadoCreate();

            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(mock), System.Text.Encoding.UTF8, "application/json");
            Console.WriteLine(contenido);

            var response = await cliente.PostAsync("https://localhost:44337/api/PresupuestoEncabezado/Insertar", contenido);
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

        [TestMethod]
        public async Task PresupuestoActualizar()
        {
            var cliente = factory.CreateClient();

            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var mock = PresupuestoMock.PresupuestoEncabezadoModel();

            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(mock), System.Text.Encoding.UTF8, "application/json");
            Console.WriteLine(contenido);

            var response = await cliente.PutAsync("https://localhost:44337/api/PresupuestoEncabezado/Actualizar", contenido);
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }
    }
}
