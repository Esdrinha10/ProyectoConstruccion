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
    public class PlanillaIntegrationTest : DbContextMocker
    {
        //Apikey
        private const string ApiKey = "4b567cb1c6b24b51ab55248f8e66e5cc";

        [TestMethod]
        public async Task PlanillaListDetalle()
        {
            var cliente = factory.CreateClient();
            //añade el apikey a al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var planillaMock = PlanillasMocks.ListarPlanilla();

            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(planillaMock), System.Text.Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("https://localhost:44337/api/Planilla/ListadoPlanilla", contenido);
            response.EnsureSuccessStatusCode();

            //aserciones 
            Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task PlanillaCreate()
        {
            // Creamos el cliente
            var cliente = factory.CreateClient();

            // Añadimos la API key al header
            cliente.DefaultRequestHeaders.Add("XApiKey", ApiKey);

            var planillaMock = PlanillasMocks.CreatePlanilla();

            // Serializamos el objeto a JSON para enviarlo en el cuerpo de la petición
            var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(planillaMock), System.Text.Encoding.UTF8, "application/json");

            // Realizamos la petición tipo POST a la URL
            var response = await cliente.PostAsync("https://localhost:44337/api/Planilla/Insertar", contenido);

            // Verificamos que el estado de la respuesta sea exitoso
            response.EnsureSuccessStatusCode();

            // Aserciones
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response);

            // Leemos el contenido de la respuesta
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(string.IsNullOrEmpty(responseContent));
        }

    }
}
